using Hume.Core;
using Hume.Test.Unit.MockServer;
using Hume.Tts;
using NUnit.Framework;

namespace Hume.Test.Unit.MockServer.Tts;

[TestFixture]
public class SynthesizeJsonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "context": {
                "utterances": [
                  {
                    "text": "How can people see beauty so differently?",
                    "description": "A curious student with a clear and respectful tone, seeking clarification on Hume's ideas with a straightforward question."
                  }
                ]
              },
              "format": {
                "type": "mp3"
              },
              "num_generations": 1,
              "utterances": [
                {
                  "text": "Beauty is no quality in things themselves: It exists merely in the mind which contemplates them.",
                  "description": "Middle-aged masculine voice with a clear, rhythmic Scots lilt, rounded vowels, and a warm, steady tone with an articulate, academic quality."
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "generations": [
                {
                  "audio": "//PExAA0DDYRvkpNfhv3JI5JZ...etc.",
                  "duration": 7.44225,
                  "encoding": {
                    "format": "mp3",
                    "sample_rate": 48000
                  },
                  "file_size": 120192,
                  "generation_id": "795c949a-1510-4a80-9646-7d0863b023ab",
                  "snippets": [
                    [
                      {
                        "audio": "//PExAA0DDYRvkpNfhv3JI5JZ...etc.",
                        "generation_id": "795c949a-1510-4a80-9646-7d0863b023ab",
                        "id": "37b1b1b1-1b1b-1b1b-1b1b-1b1b1b1b1b1b",
                        "text": "Beauty is no quality in things themselves: It exists merely in the mind which contemplates them.",
                        "utterance_index": 0,
                        "timestamps": []
                      }
                    ]
                  ]
                }
              ],
              "request_id": "66e01f90-4501-4aa0-bbaf-74f45dc15aa725906"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v0/tts")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tts.SynthesizeJsonAsync(
            new PostedTts
            {
                Context = new PostedContextWithUtterances
                {
                    Utterances = new List<PostedUtterance>()
                    {
                        new PostedUtterance
                        {
                            Text = "How can people see beauty so differently?",
                            Description =
                                "A curious student with a clear and respectful tone, seeking clarification on Hume's ideas with a straightforward question.",
                        },
                    },
                },
                Format = new FormatMp3 { Type = "mp3" },
                NumGenerations = 1,
                Utterances = new List<PostedUtterance>()
                {
                    new PostedUtterance
                    {
                        Text =
                            "Beauty is no quality in things themselves: It exists merely in the mind which contemplates them.",
                        Description =
                            "Middle-aged masculine voice with a clear, rhythmic Scots lilt, rounded vowels, and a warm, steady tone with an articulate, academic quality.",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ReturnTts>(mockResponse)).UsingDefaults()
        );
    }
}

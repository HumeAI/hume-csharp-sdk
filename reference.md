# Reference
## Tts Voices
<details><summary><code>client.Tts.Voices.<a href="/src/Hume/Tts/Voices/VoicesClient.cs">ListAsync</a>(Tts.VoicesListRequest { ... }) -> Hume.Core.Pager<Tts.ReturnVoice></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists voices you have saved in your account, or voices from the [Voice Library](https://platform.hume.ai/tts/voice-library).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tts.Voices.ListAsync(
    new VoicesListRequest { Provider = Hume.Tts.VoiceProvider.CustomVoice }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.VoicesListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tts.Voices.<a href="/src/Hume/Tts/Voices/VoicesClient.cs">CreateAsync</a>(Tts.PostedVoice { ... }) -> Tts.ReturnVoice</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Saves a new custom voice to your account using the specified TTS generation ID.

Once saved, this voice can be reused in subsequent TTS requests, ensuring consistent speech style and prosody. For more details on voice creation, see the [Voices Guide](/docs/text-to-speech-tts/voices).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tts.Voices.CreateAsync(
    new PostedVoice { GenerationId = "795c949a-1510-4a80-9646-7d0863b023ab", Name = "David Hume" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.PostedVoice` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tts.Voices.<a href="/src/Hume/Tts/Voices/VoicesClient.cs">DeleteAsync</a>(Tts.VoicesDeleteRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a previously generated custom voice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tts.Voices.DeleteAsync(new VoicesDeleteRequest { Name = "David Hume" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.VoicesDeleteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Tts
<details><summary><code>client.Tts.<a href="/src/Hume/Tts/TtsClient.cs">SynthesizeJsonAsync</a>(Tts.PostedTts { ... }) -> Tts.ReturnTts</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Synthesizes one or more input texts into speech using the specified voice. If no voice is provided, a novel voice will be generated dynamically. Optionally, additional context can be included to influence the speech's style and prosody.

The response includes the base64-encoded audio and metadata in JSON format.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tts.SynthesizeJsonAsync(
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
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.PostedTts` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tts.<a href="/src/Hume/Tts/TtsClient.cs">SynthesizeFileAsync</a>(Tts.PostedTts { ... }) -> System.IO.Stream</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Synthesizes one or more input texts into speech using the specified voice. If no voice is provided, a novel voice will be generated dynamically. Optionally, additional context can be included to influence the speech's style and prosody. 

The response contains the generated audio file in the requested format.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tts.SynthesizeFileAsync(
    new PostedTts
    {
        Context = new PostedContextWithGenerationId
        {
            GenerationId = "09ad914d-8e7f-40f8-a279-e34f07f7dab2",
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
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.PostedTts` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tts.<a href="/src/Hume/Tts/TtsClient.cs">SynthesizeFileStreamingAsync</a>(Tts.PostedTts { ... }) -> System.IO.Stream</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Streams synthesized speech using the specified voice. If no voice is provided, a novel voice will be generated dynamically. Optionally, additional context can be included to influence the speech's style and prosody.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tts.SynthesizeFileStreamingAsync(
    new PostedTts
    {
        Utterances = new List<PostedUtterance>()
        {
            new PostedUtterance
            {
                Text =
                    "Beauty is no quality in things themselves: It exists merely in the mind which contemplates them.",
                Voice = new PostedUtteranceVoiceWithName
                {
                    Name = "Male English Actor",
                    Provider = Hume.Tts.VoiceProvider.HumeAi,
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.PostedTts` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tts.<a href="/src/Hume/Tts/TtsClient.cs">SynthesizeJsonStreamingAsync</a>(Tts.PostedTts { ... }) -> System.Collections.Generic.IAsyncEnumerable<OneOf.OneOf<Tts.TimestampMessage, Tts.SnippetAudioChunk>></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Streams synthesized speech using the specified voice. If no voice is provided, a novel voice will be generated dynamically. Optionally, additional context can be included to influence the speech's style and prosody. 

The response is a stream of JSON objects including audio encoded in base64.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
client.Tts.SynthesizeJsonStreamingAsync(
    new PostedTts
    {
        Utterances = new List<PostedUtterance>()
        {
            new PostedUtterance
            {
                Text =
                    "Beauty is no quality in things themselves: It exists merely in the mind which contemplates them.",
                Voice = new PostedUtteranceVoiceWithName
                {
                    Name = "Male English Actor",
                    Provider = Hume.Tts.VoiceProvider.HumeAi,
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Tts.PostedTts` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EmpathicVoice Tools
<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">ListToolsAsync</a>(EmpathicVoice.ToolsListToolsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnUserDefinedTool></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Tools**.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.ListToolsAsync(
    new ToolsListToolsRequest { PageNumber = 0, PageSize = 2 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.ToolsListToolsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">CreateToolAsync</a>(EmpathicVoice.PostedUserDefinedTool { ... }) -> EmpathicVoice.ReturnUserDefinedTool?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a **Tool** that can be added to an [EVI configuration](/reference/speech-to-speech-evi/configs/create-config).

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.CreateToolAsync(
    new PostedUserDefinedTool
    {
        Name = "get_current_weather",
        Parameters =
            "{ \"type\": \"object\", \"properties\": { \"location\": { \"type\": \"string\", \"description\": \"The city and state, e.g. San Francisco, CA\" }, \"format\": { \"type\": \"string\", \"enum\": [\"celsius\", \"fahrenheit\"], \"description\": \"The temperature unit to use. Infer this from the users location.\" } }, \"required\": [\"location\", \"format\"] }",
        VersionDescription =
            "Fetches current weather and uses celsius or fahrenheit based on location of user.",
        Description = "This tool is for getting the current weather.",
        FallbackContent = "Unable to fetch current weather.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.PostedUserDefinedTool` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">ListToolVersionsAsync</a>(id, EmpathicVoice.ToolsListToolVersionsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnUserDefinedTool></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a list of a **Tool's** versions.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.ListToolVersionsAsync(
    "00183a3f-79ba-413d-9f3b-609864268bea",
    new ToolsListToolVersionsRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.ToolsListToolVersionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">CreateToolVersionAsync</a>(id, EmpathicVoice.PostedUserDefinedToolVersion { ... }) -> EmpathicVoice.ReturnUserDefinedTool?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a **Tool** by creating a new version of the **Tool**.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.CreateToolVersionAsync(
    "00183a3f-79ba-413d-9f3b-609864268bea",
    new PostedUserDefinedToolVersion
    {
        Parameters =
            "{ \"type\": \"object\", \"properties\": { \"location\": { \"type\": \"string\", \"description\": \"The city and state, e.g. San Francisco, CA\" }, \"format\": { \"type\": \"string\", \"enum\": [\"celsius\", \"fahrenheit\", \"kelvin\"], \"description\": \"The temperature unit to use. Infer this from the users location.\" } }, \"required\": [\"location\", \"format\"] }",
        VersionDescription =
            "Fetches current weather and uses celsius, fahrenheit, or kelvin based on location of user.",
        FallbackContent = "Unable to fetch current weather.",
        Description = "This tool is for getting the current weather.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedUserDefinedToolVersion` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">DeleteToolAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a **Tool** and its versions.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.DeleteToolAsync("00183a3f-79ba-413d-9f3b-609864268bea");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">UpdateToolNameAsync</a>(id, EmpathicVoice.PostedUserDefinedToolName { ... }) -> string</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the name of a **Tool**.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.UpdateToolNameAsync(
    "00183a3f-79ba-413d-9f3b-609864268bea",
    new PostedUserDefinedToolName { Name = "get_current_temperature" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedUserDefinedToolName` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">GetToolVersionAsync</a>(id, version) -> EmpathicVoice.ReturnUserDefinedTool?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a specified version of a **Tool**.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.GetToolVersionAsync("00183a3f-79ba-413d-9f3b-609864268bea", 1);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Tool.

Tools, Configs, Custom Voices, and Prompts are versioned. This versioning system supports iterative development, allowing you to progressively refine tools and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Tool. Each update to the Tool increments its version number.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">DeleteToolVersionAsync</a>(id, version)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a specified version of a **Tool**.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.DeleteToolVersionAsync("00183a3f-79ba-413d-9f3b-609864268bea", 1);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Tool.

Tools, Configs, Custom Voices, and Prompts are versioned. This versioning system supports iterative development, allowing you to progressively refine tools and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Tool. Each update to the Tool increments its version number.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Tools.<a href="/src/Hume/EmpathicVoice/Tools/ToolsClient.cs">UpdateToolDescriptionAsync</a>(id, version, EmpathicVoice.PostedUserDefinedToolVersionDescription { ... }) -> EmpathicVoice.ReturnUserDefinedTool?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the description of a specified **Tool** version.

Refer to our [tool use](/docs/speech-to-speech-evi/features/tool-use#function-calling) guide for comprehensive instructions on defining and integrating tools into EVI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Tools.UpdateToolDescriptionAsync(
    "00183a3f-79ba-413d-9f3b-609864268bea",
    1,
    new PostedUserDefinedToolVersionDescription
    {
        VersionDescription =
            "Fetches current temperature, precipitation, wind speed, AQI, and other weather conditions. Uses Celsius, Fahrenheit, or kelvin depending on user's region.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Tool. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Tool.

Tools, Configs, Custom Voices, and Prompts are versioned. This versioning system supports iterative development, allowing you to progressively refine tools and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Tool. Each update to the Tool increments its version number.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedUserDefinedToolVersionDescription` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EmpathicVoice Prompts
<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">ListPromptsAsync</a>(EmpathicVoice.PromptsListPromptsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnPrompt></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Prompts**.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.ListPromptsAsync(
    new PromptsListPromptsRequest { PageNumber = 0, PageSize = 2 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.PromptsListPromptsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">CreatePromptAsync</a>(EmpathicVoice.PostedPrompt { ... }) -> EmpathicVoice.ReturnPrompt?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a **Prompt** that can be added to an [EVI configuration](/reference/speech-to-speech-evi/configs/create-config).

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.CreatePromptAsync(
    new PostedPrompt
    {
        Name = "Weather Assistant Prompt",
        Text =
            "<role>You are an AI weather assistant providing users with accurate and up-to-date weather information. Respond to user queries concisely and clearly. Use simple language and avoid technical jargon. Provide temperature, precipitation, wind conditions, and any weather alerts. Include helpful tips if severe weather is expected.</role>",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.PostedPrompt` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">ListPromptVersionsAsync</a>(id, EmpathicVoice.PromptsListPromptVersionsRequest { ... }) -> EmpathicVoice.ReturnPagedPrompts</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a list of a **Prompt's** versions.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.ListPromptVersionsAsync(
    "af699d45-2985-42cc-91b9-af9e5da3bac5",
    new PromptsListPromptVersionsRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PromptsListPromptVersionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">CreatePromptVersionAsync</a>(id, EmpathicVoice.PostedPromptVersion { ... }) -> EmpathicVoice.ReturnPrompt?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a **Prompt** by creating a new version of the **Prompt**.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.CreatePromptVersionAsync(
    "af699d45-2985-42cc-91b9-af9e5da3bac5",
    new PostedPromptVersion
    {
        Text =
            "<role>You are an updated version of an AI weather assistant providing users with accurate and up-to-date weather information. Respond to user queries concisely and clearly. Use simple language and avoid technical jargon. Provide temperature, precipitation, wind conditions, and any weather alerts. Include helpful tips if severe weather is expected.</role>",
        VersionDescription = "This is an updated version of the Weather Assistant Prompt.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedPromptVersion` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">DeletePromptAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a **Prompt** and its versions.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.DeletePromptAsync("af699d45-2985-42cc-91b9-af9e5da3bac5");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">UpdatePromptNameAsync</a>(id, EmpathicVoice.PostedPromptName { ... }) -> string</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the name of a **Prompt**.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.UpdatePromptNameAsync(
    "af699d45-2985-42cc-91b9-af9e5da3bac5",
    new PostedPromptName { Name = "Updated Weather Assistant Prompt Name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedPromptName` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">GetPromptVersionAsync</a>(id, version) -> EmpathicVoice.ReturnPrompt?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a specified version of a **Prompt**.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.GetPromptVersionAsync("af699d45-2985-42cc-91b9-af9e5da3bac5", 0);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Prompt.

Prompts, Configs, Custom Voices, and Tools are versioned. This versioning system supports iterative development, allowing you to progressively refine prompts and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Prompt. Each update to the Prompt increments its version number.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">DeletePromptVersionAsync</a>(id, version)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a specified version of a **Prompt**.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.DeletePromptVersionAsync(
    "af699d45-2985-42cc-91b9-af9e5da3bac5",
    1
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Prompt.

Prompts, Configs, Custom Voices, and Tools are versioned. This versioning system supports iterative development, allowing you to progressively refine prompts and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Prompt. Each update to the Prompt increments its version number.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Prompts.<a href="/src/Hume/EmpathicVoice/Prompts/PromptsClient.cs">UpdatePromptDescriptionAsync</a>(id, version, EmpathicVoice.PostedPromptVersionDescription { ... }) -> EmpathicVoice.ReturnPrompt?</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the description of a **Prompt**.

See our [prompting guide](/docs/speech-to-speech-evi/guides/phone-calling) for tips on crafting your system prompt.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Prompts.UpdatePromptDescriptionAsync(
    "af699d45-2985-42cc-91b9-af9e5da3bac5",
    1,
    new PostedPromptVersionDescription
    {
        VersionDescription = "This is an updated version_description.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Prompt. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Prompt.

Prompts, Configs, Custom Voices, and Tools are versioned. This versioning system supports iterative development, allowing you to progressively refine prompts and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Prompt. Each update to the Prompt increments its version number.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedPromptVersionDescription` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EmpathicVoice Configs
<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">ListConfigsAsync</a>(EmpathicVoice.ConfigsListConfigsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnConfig></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Configs**.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.ListConfigsAsync(
    new ConfigsListConfigsRequest { PageNumber = 0, PageSize = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.ConfigsListConfigsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">CreateConfigAsync</a>(EmpathicVoice.PostedConfig { ... }) -> EmpathicVoice.ReturnConfig</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a **Config** which can be applied to EVI.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.CreateConfigAsync(
    new PostedConfig
    {
        Name = "Weather Assistant Config",
        Prompt = new PostedConfigPromptSpec
        {
            Id = "af699d45-2985-42cc-91b9-af9e5da3bac5",
            Version = 0,
        },
        EviVersion = "3",
        Voice = new VoiceName
        {
            Provider = Hume.EmpathicVoice.VoiceProvider.HumeAi,
            Name = "Ava Song",
        },
        LanguageModel = new PostedLanguageModel
        {
            ModelProvider = ModelProviderEnum.Anthropic,
            ModelResource = LanguageModelType.Claude37SonnetLatest,
            Temperature = 1f,
        },
        EventMessages = new PostedEventMessageSpecs
        {
            OnNewChat = new PostedEventMessageSpec { Enabled = false, Text = "" },
            OnInactivityTimeout = new PostedEventMessageSpec { Enabled = false, Text = "" },
            OnMaxDurationTimeout = new PostedEventMessageSpec { Enabled = false, Text = "" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.PostedConfig` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">ListConfigVersionsAsync</a>(id, EmpathicVoice.ConfigsListConfigVersionsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnConfig></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a list of a **Config's** versions.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.ListConfigVersionsAsync(
    "1b60e1a0-cc59-424a-8d2c-189d354db3f3",
    new ConfigsListConfigVersionsRequest()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.ConfigsListConfigVersionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">CreateConfigVersionAsync</a>(id, EmpathicVoice.PostedConfigVersion { ... }) -> EmpathicVoice.ReturnConfig</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a **Config** by creating a new version of the **Config**.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.CreateConfigVersionAsync(
    "1b60e1a0-cc59-424a-8d2c-189d354db3f3",
    new PostedConfigVersion
    {
        VersionDescription = "This is an updated version of the Weather Assistant Config.",
        EviVersion = "3",
        Prompt = new PostedConfigPromptSpec
        {
            Id = "af699d45-2985-42cc-91b9-af9e5da3bac5",
            Version = 0,
        },
        Voice = new VoiceName
        {
            Provider = Hume.EmpathicVoice.VoiceProvider.HumeAi,
            Name = "Ava Song",
        },
        LanguageModel = new PostedLanguageModel
        {
            ModelProvider = ModelProviderEnum.Anthropic,
            ModelResource = LanguageModelType.Claude37SonnetLatest,
            Temperature = 1f,
        },
        EllmModel = new PostedEllmModel { AllowShortResponses = true },
        EventMessages = new PostedEventMessageSpecs
        {
            OnNewChat = new PostedEventMessageSpec { Enabled = false, Text = "" },
            OnInactivityTimeout = new PostedEventMessageSpec { Enabled = false, Text = "" },
            OnMaxDurationTimeout = new PostedEventMessageSpec { Enabled = false, Text = "" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedConfigVersion` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">DeleteConfigAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a **Config** and its versions.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.DeleteConfigAsync("1b60e1a0-cc59-424a-8d2c-189d354db3f3");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">UpdateConfigNameAsync</a>(id, EmpathicVoice.PostedConfigName { ... }) -> string</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the name of a **Config**.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.UpdateConfigNameAsync(
    "1b60e1a0-cc59-424a-8d2c-189d354db3f3",
    new PostedConfigName { Name = "Updated Weather Assistant Config Name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedConfigName` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">GetConfigVersionAsync</a>(id, version) -> EmpathicVoice.ReturnConfig</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a specified version of a **Config**.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.GetConfigVersionAsync("1b60e1a0-cc59-424a-8d2c-189d354db3f3", 1);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Config.

Configs, Prompts, Custom Voices, and Tools are versioned. This versioning system supports iterative development, allowing you to progressively refine configurations and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Config. Each update to the Config increments its version number.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">DeleteConfigVersionAsync</a>(id, version)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a specified version of a **Config**.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.DeleteConfigVersionAsync(
    "1b60e1a0-cc59-424a-8d2c-189d354db3f3",
    1
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Config.

Configs, Prompts, Custom Voices, and Tools are versioned. This versioning system supports iterative development, allowing you to progressively refine configurations and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Config. Each update to the Config increments its version number.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Configs.<a href="/src/Hume/EmpathicVoice/Configs/ConfigsClient.cs">UpdateConfigDescriptionAsync</a>(id, version, EmpathicVoice.PostedConfigVersionDescription { ... }) -> EmpathicVoice.ReturnConfig</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the description of a **Config**.

For more details on configuration options and how to configure EVI, see our [configuration guide](/docs/speech-to-speech-evi/configuration).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Configs.UpdateConfigDescriptionAsync(
    "1b60e1a0-cc59-424a-8d2c-189d354db3f3",
    1,
    new PostedConfigVersionDescription
    {
        VersionDescription = "This is an updated version_description.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Config. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**version:** `int` 

Version number for a Config.

Configs, Prompts, Custom Voices, and Tools are versioned. This versioning system supports iterative development, allowing you to progressively refine configurations and revert to previous versions if needed.

Version numbers are integer values representing different iterations of the Config. Each update to the Config increments its version number.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.PostedConfigVersionDescription` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EmpathicVoice Chats
<details><summary><code>client.EmpathicVoice.Chats.<a href="/src/Hume/EmpathicVoice/Chats/ChatsClient.cs">ListChatsAsync</a>(EmpathicVoice.ChatsListChatsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnChat></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Chats**.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Chats.ListChatsAsync(
    new ChatsListChatsRequest
    {
        PageNumber = 0,
        PageSize = 1,
        AscendingOrder = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.ChatsListChatsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Chats.<a href="/src/Hume/EmpathicVoice/Chats/ChatsClient.cs">ListChatEventsAsync</a>(id, EmpathicVoice.ChatsListChatEventsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnChatEvent></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Chat** events.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Chats.ListChatEventsAsync(
    "470a49f6-1dec-4afe-8b61-035d3b2d63b0",
    new ChatsListChatEventsRequest
    {
        PageNumber = 0,
        PageSize = 3,
        AscendingOrder = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Chat. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.ChatsListChatEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.Chats.<a href="/src/Hume/EmpathicVoice/Chats/ChatsClient.cs">GetAudioAsync</a>(id) -> EmpathicVoice.ReturnChatAudioReconstruction</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches the audio of a previous **Chat**. For more details, see our guide on audio reconstruction [here](/docs/speech-to-speech-evi/faq#can-i-access-the-audio-of-previous-conversations-with-evi).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.Chats.GetAudioAsync("470a49f6-1dec-4afe-8b61-035d3b2d63b0");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a chat. Formatted as a UUID.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EmpathicVoice ChatGroups
<details><summary><code>client.EmpathicVoice.ChatGroups.<a href="/src/Hume/EmpathicVoice/ChatGroups/ChatGroupsClient.cs">ListChatGroupsAsync</a>(EmpathicVoice.ChatGroupsListChatGroupsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnChatGroup></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Chat Groups**.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.ChatGroups.ListChatGroupsAsync(
    new ChatGroupsListChatGroupsRequest
    {
        PageNumber = 0,
        PageSize = 1,
        AscendingOrder = true,
        ConfigId = "1b60e1a0-cc59-424a-8d2c-189d354db3f3",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmpathicVoice.ChatGroupsListChatGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.ChatGroups.<a href="/src/Hume/EmpathicVoice/ChatGroups/ChatGroupsClient.cs">GetChatGroupAsync</a>(id, EmpathicVoice.ChatGroupsGetChatGroupRequest { ... }) -> EmpathicVoice.ReturnChatGroupPagedChats</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a **ChatGroup** by ID, including a paginated list of **Chats** associated with the **ChatGroup**.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.ChatGroups.GetChatGroupAsync(
    "697056f0-6c7e-487d-9bd8-9c19df79f05f",
    new ChatGroupsGetChatGroupRequest
    {
        PageNumber = 0,
        PageSize = 1,
        AscendingOrder = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Chat Group. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.ChatGroupsGetChatGroupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.ChatGroups.<a href="/src/Hume/EmpathicVoice/ChatGroups/ChatGroupsClient.cs">ListChatGroupEventsAsync</a>(id, EmpathicVoice.ChatGroupsListChatGroupEventsRequest { ... }) -> Hume.Core.Pager<EmpathicVoice.ReturnChatEvent></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of **Chat** events associated with a **Chat Group**.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.ChatGroups.ListChatGroupEventsAsync(
    "697056f0-6c7e-487d-9bd8-9c19df79f05f",
    new ChatGroupsListChatGroupEventsRequest
    {
        PageNumber = 0,
        PageSize = 3,
        AscendingOrder = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Chat Group. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.ChatGroupsListChatGroupEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmpathicVoice.ChatGroups.<a href="/src/Hume/EmpathicVoice/ChatGroups/ChatGroupsClient.cs">GetAudioAsync</a>(id, EmpathicVoice.ChatGroupsGetAudioRequest { ... }) -> EmpathicVoice.ReturnChatGroupPagedAudioReconstructions</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches a paginated list of audio for each **Chat** within the specified **Chat Group**. For more details, see our guide on audio reconstruction [here](/docs/speech-to-speech-evi/faq#can-i-access-the-audio-of-previous-conversations-with-evi).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmpathicVoice.ChatGroups.GetAudioAsync(
    "369846cf-6ad5-404d-905e-a8acb5cdfc78",
    new ChatGroupsGetAudioRequest
    {
        PageNumber = 0,
        PageSize = 10,
        AscendingOrder = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Identifier for a Chat Group. Formatted as a UUID.
    
</dd>
</dl>

<dl>
<dd>

**request:** `EmpathicVoice.ChatGroupsGetAudioRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ExpressionMeasurement Batch
<details><summary><code>client.ExpressionMeasurement.Batch.<a href="/src/Hume/ExpressionMeasurement/Batch/BatchClient.cs">ListJobsAsync</a>(Hume.ExpressionMeasurement.Batch.BatchListJobsRequest { ... }) -> IEnumerable<Hume.ExpressionMeasurement.Batch.InferenceJob></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sort and filter jobs.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ExpressionMeasurement.Batch.ListJobsAsync(new BatchListJobsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Hume.ExpressionMeasurement.Batch.BatchListJobsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ExpressionMeasurement.Batch.<a href="/src/Hume/ExpressionMeasurement/Batch/BatchClient.cs">StartInferenceJobAsync</a>(Hume.ExpressionMeasurement.Batch.InferenceBaseRequest { ... }) -> Hume.ExpressionMeasurement.Batch.JobId</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Start a new measurement inference job.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ExpressionMeasurement.Batch.StartInferenceJobAsync(
    new InferenceBaseRequest
    {
        Urls = new List<string>() { "https://hume-tutorials.s3.amazonaws.com/faces.zip" },
        Notify = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Hume.ExpressionMeasurement.Batch.InferenceBaseRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ExpressionMeasurement.Batch.<a href="/src/Hume/ExpressionMeasurement/Batch/BatchClient.cs">GetJobDetailsAsync</a>(id) -> Hume.ExpressionMeasurement.Batch.InferenceJob</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the request details and state of a given job.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ExpressionMeasurement.Batch.GetJobDetailsAsync("job_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The unique identifier for the job.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ExpressionMeasurement.Batch.<a href="/src/Hume/ExpressionMeasurement/Batch/BatchClient.cs">GetJobPredictionsAsync</a>(id) -> IEnumerable<Hume.ExpressionMeasurement.Batch.InferenceSourcePredictResult></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the JSON predictions of a completed inference job.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ExpressionMeasurement.Batch.GetJobPredictionsAsync("job_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The unique identifier for the job.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

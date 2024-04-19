using Newtonsoft.Json.Linq;
using SayyehBanTools.Translation.Google.Model;

namespace SayyehBanTools.Translation.Google;

public class TranslateTexts
{
    private readonly HttpClient _httpClient;

    public TranslateTexts(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TranslationResponse> TranslateTextAsync(TranslationRequest request)
    {
        string url = $"https://translate.google.com/translate_a/single?client=gtx&sl={request.InputLanguage}&tl={request.OutputLanguage}&dt=t&q={request.OriginalText}";

        using (var response = await _httpClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                string responseText = await response.Content.ReadAsStringAsync();
                JArray jsonResponse = JArray.Parse(responseText);

                JArray translationParts = (JArray)jsonResponse[0];
                List<string> translatedParts = new List<string>();

                foreach (JArray part in translationParts)
                {
                    string translatedText = (string)part[0];
                    translatedParts.Add(translatedText);
                }

                return new TranslationResponse { Translations = translatedParts };
            }
            else
            {
                throw new Exception("Translation request failed. Status code: " + response.StatusCode);
            }
        }
    }
}
/*
 طریقه استفاده از دستور
using API.Model;
using Microsoft.AspNetCore.Mvc;
using SayyehBanTools.Translation.Google;
using SayyehBanTools.Translation.Google.Model;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TranslateController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TranslationResponse>> TranslateText([FromQuery] TranslationRequest request)
    {
        var translator = new TranslateTexts(new HttpClient());

        var translationResponse = await translator.TranslateTextAsync(request); // Use the parameter directly

        if (translationResponse != null)
        {
            Console.WriteLine("Translated text:");
            foreach (string translatedPart in translationResponse.Translations)
            {
                Console.WriteLine(translatedPart);
            }
        }
        else
        {
            Console.WriteLine("Translation failed.");
        }

        return translationResponse;
    }
}


 */
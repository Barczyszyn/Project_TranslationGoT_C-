using FunTranslations;

string response = string.Empty;
string language = string.Empty;

do
{
    Console.WriteLine("Qual frase você gostaria de traduzir para GoT?");
    response = Console.ReadLine();
    response.Trim();

    if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
    {
        Console.WriteLine("Frase inválida!\nEscreva uma frase válida!");
        response = Console.ReadLine();
        response.Trim();

        while (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("Frase inválida!\nEscreva uma frase válida!");
            response = Console.ReadLine();
            response.Trim();
        }
    }

    if (response.ToLower() == "sair")
    {
        break;
    }

    Console.WriteLine("Escolha entre valiriano (v) ou dothraki (d).");
    language = Console.ReadLine();
    language.Trim();

    if (string.IsNullOrEmpty(language) || string.IsNullOrWhiteSpace(language) || (!language.ToLower().Equals("v") && !language.ToLower().Equals("d")))
    {
        Console.WriteLine("Língua inválida!\nEscolha uma língua válida! Digite (v) para valiriano ou (d) para dothraki!");
        language = Console.ReadLine();
        language.Trim();

        while (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response) || (!language.ToLower().Equals("v") && !language.ToLower().Equals("d")))
        {
            Console.WriteLine("Língua inválida!\nEscolha uma língua válida! Digite (v) para valiriano ou (d) para dothraki!");
            language = Console.ReadLine();
            language.Trim();
        }
    }

    if (language.Equals("v"))
    {
        language = "valyrian";
    } else
    {
        language = "dothraki";
    }

    TranslationService translationService = new TranslationService($"http://api.funtranslations.com/translate/{language}");
    string translatedText = await translationService.Translate(response);
    
    Console.WriteLine($"Tradução em {language}: {translatedText}\nPara sair digite 'sair'");
} while (response.ToLower() != "sair");
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class questoes{

   
    public static void questao01(){
    Console.WriteLine("QUESTÃO 01!");
    int INDICE = 13, SOMA = 0, K = 0;

    while (K < INDICE)
    {
    K = K + 1;
    SOMA = SOMA + K;
    }

    Console.WriteLine("A variavel soma terá o valor de {0} ao final do programa", SOMA);

    }
    
     public static void questao02(){
        Console.WriteLine("QUESTÃO 02!");
        Console.Write("Digite um número: ");
        int numero = int.Parse(Console.ReadLine());

        if (PertenceAFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {numero} não pertence à sequência de Fibonacci.");
        }
    }

    static bool PertenceAFibonacci(int numero)
    {
       
        int a = 0;
        int b = 1;

        if (numero == a || numero == b) return true;

      
        int proximo = a + b;
        while (proximo <= numero)
        {
            if (proximo == numero)
            {
                return true;
            }
            a = b;
            b = proximo;
            proximo = a + b;
        }

        return false;
    }
    public static void questao03(){
        Console.WriteLine("QUESTÃO 03!");

        string jsonFilePath = "arrayquestao03.json";
        List<FaturamentoDiario> faturamentos = CarregarFaturamento(jsonFilePath);

    
        var diasComFaturamento = faturamentos.Where(f => f.Faturamento > 0).ToList();

        
        if (!diasComFaturamento.Any())
        {
            Console.WriteLine("Não há dias com faturamento positivo para calcular.");
            return;
        }

        double menorFaturamento = diasComFaturamento.Min(f => f.Faturamento);
        double maiorFaturamento = diasComFaturamento.Max(f => f.Faturamento);

        double mediaMensal = diasComFaturamento.Average(f => f.Faturamento);

        int diasAcimaDaMedia = diasComFaturamento.Count(f => f.Faturamento > mediaMensal);

        Console.WriteLine($"Menor faturamento diário: {menorFaturamento}");
        Console.WriteLine($"Maior faturamento diário: {maiorFaturamento}");
        Console.WriteLine($"Número de dias com faturamento acima da média mensal: {diasAcimaDaMedia}");

        static List<FaturamentoDiario> CarregarFaturamento(string caminhoArquivo){
            try
        {
            string jsonData = File.ReadAllText(caminhoArquivo);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<FaturamentoDiario>>(jsonData, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados: {ex.Message}");
                return new List<FaturamentoDiario>();
            }
        }
    
    }
    public static void questao04(){
        Console.WriteLine("questao04");
        var faturamentos = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

       
        double faturamentoTotal = 0;
        foreach (var faturamento in faturamentos.Values)
        {
            faturamentoTotal += faturamento;
        }

        Console.WriteLine("Percentual de representação por estado:");
        
        
        foreach (var estado in faturamentos)
        {
            double percentual = (estado.Value / faturamentoTotal) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }
    }
    public static void questao05(){
        Console.WriteLine("Questao05");
        
        Console.WriteLine("Digite uma string para inverter (ou pressione Enter para usar a string padrão):");
        string entrada = Console.ReadLine();

        
        if (string.IsNullOrWhiteSpace(entrada))
        {
            entrada = "Exemplo de string padrão.";
        }

       
        string stringInvertida = InverterString(entrada);
        
      
        Console.WriteLine($"String original: {entrada}");
        Console.WriteLine($"String invertida: {stringInvertida}");
    }

    static string InverterString(string str)
    {
        char[] caracteres = new char[str.Length]; 
        int index = 0;

       
        for (int i = str.Length - 1; i >= 0; i--)
        {
            caracteres[index] = str[i];
            index++;
        }

        
        return new string(caracteres);
    }
}

      

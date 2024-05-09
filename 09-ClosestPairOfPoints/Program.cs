// TITLE GUESS
// Chapter 9 (See in Action)
// C# Data Structures and Algorithms, Second Edition

const string Genes = "abcdefghijklmnopqrstuvwxyz#ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
const string Target = "C# Data Structures and Algorithms";

Random random = new();
int generationNo = 0;
List<Individual> population = [];

for (int i = 0; i < 1000; i++)
{
    string chromosome = GetRandomChromosome();
    population.Add(new(chromosome, GetFitness(chromosome)));
}

List<Individual> generation = [];
while (true)
{
    population.Sort((a, b) => b.Fitness.CompareTo(a.Fitness));
    if (population[0].Fitness == Target.Length)
    {
        Print();
        break;
    }

    generation.Clear();

    for (int i = 0; i < 200; i++)
    {
        generation.Add(population[i]);
    }

    for (int i = 0; i < 800; i++)
    {
        Individual p1 = population[random.Next(400)];
        Individual p2 = population[random.Next(400)];
        Individual offspring = Mate(p1, p2);
        generation.Add(offspring);
    }

    population.Clear();
    population.AddRange(generation);
    Print();
    generationNo++;
}

Individual Mate(Individual p1, Individual p2)
{
    string child = string.Empty;
    for (int i = 0; i < Target.Length; i++)
    {
        float r = random.Next(101) / 100.0f;
        if (r < 0.45f) { child += p1.Chromosome[i]; }
        else if (r < 0.9f) { child += p2.Chromosome[i]; }
        else { child += GetRandomGene(); }
    }

    return new Individual(child, GetFitness(child));
}

char GetRandomGene() => Genes[random.Next(Genes.Length)];

string GetRandomChromosome()
{
    string chromosome = string.Empty;
    for (int i = 0; i < Target.Length; i++)
    { 
        chromosome += GetRandomGene(); 
    }

    return chromosome;
}

int GetFitness(string chromosome)
{
    int fitness = 0;
    for (int i = 0; i < Target.Length; i++)
    {
        if (chromosome[i] == Target[i]) { fitness++; }
    }

    return fitness;
}

void Print() => Console.WriteLine(
    $"Generation {generationNo:D2}: {population[0].Chromosome} / {population[0].Fitness}");

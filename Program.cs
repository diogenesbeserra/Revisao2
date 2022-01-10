using System;

namespace Revisao2
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //adicionar aluno
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Informe a nota do aluno " + aluno.Nome);

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser Numérico");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        //listar aluno
                        foreach (var a in alunos)
                        {

                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno {a.Nome} Nota {a.Nota}");
                            }
                        }

                        break;
                    case "3":
                        //calcular media geral
                        decimal notaGeral = 0;
                        decimal mediaGeral = 0;
                        var quantidadeAlunos = 0;
                        ConceitoEnum conceitoGeral;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaGeral += alunos[i].Nota;
                                quantidadeAlunos++;
                            }
                        }

                        mediaGeral = notaGeral / quantidadeAlunos;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }

                        Console.WriteLine("");
                        Console.WriteLine($"Média geral dos alunos = {mediaGeral} - Conceito {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine();

            return opcaoUsuario;
        }
    }
}

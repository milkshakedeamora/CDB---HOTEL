namespace ReservaEmHotel
{
    internal class Program
    {
        static List<Pessoa> pessoas = new List<Pessoa>();
        static List<Suite> suites = new List<Suite>();
        static List<Reserva> reservas = new List<Reserva>();

        static void Main(string[] args)
        {
            int escolha;
            do
            {
                MostrarMenu();

                escolha = ObterEscolhaUsuario();

                switch (escolha)
                {
                    case 1:
                        Cadastro();
                        break;
                    case 2:
                        Consultar();
                        
                        break;
                    case 3:
                        Listar();
                        
                        break;
                    case 4:
                        Console.WriteLine("Opção SAIR.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            } while (escolha != 4);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Cadastro");
            Console.WriteLine("2. Consultar");
            Console.WriteLine("3. Listar");
            Console.WriteLine("4. Opção SAIR");
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro:");
            Console.WriteLine("1. Hóspede");
            Console.WriteLine("2. Suíte");
            Console.WriteLine("3. Reserva");

            int escolhaCadastro = ObterEscolhaUsuario();

            switch (escolhaCadastro)
            {
                case 1:
                    CadastrarHospede();
                    break;
                case 2:
                    CadastrarSuite();
                    break;
                case 3:
                    CadastrarReserva();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }

        static void Consultar()
        {
            Console.WriteLine("Cadastro:");
            Console.WriteLine("1. Hóspede");
            Console.WriteLine("2. Suíte");
            Console.WriteLine("3. Reserva");

            int escolhaCadastro = ObterEscolhaUsuario();

            switch (escolhaCadastro)
            {
                case 1:
                    EncontrarHospede();
                    break;
                case 2:
                    EncontrarSuite();
                    break;
                case 3:
                    EncontrarReserva();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }

        static void Listar()
        {
            Console.WriteLine("Cadastro:");
            Console.WriteLine("1. Hóspede");
            Console.WriteLine("2. Suíte");
            Console.WriteLine("3. Reserva");

            int escolhaCadastro = ObterEscolhaUsuario();

            switch (escolhaCadastro)
            {
                case 1:
                    for (int i = 0; i < pessoas.Count; i++)
                    {
                        pessoas[i].ListarInformações(); 
                    }
                        
                    break;
                case 2:
                    for (int i = 0; i < suites.Count; i++)
                    {
                        suites[i].ListarInformações();
                    }
                    break;
                case 3:
                    for (int i = 0; i < reservas.Count; i++)
                    {
                        reservas[i].ListarInformações();
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }

        static void CadastrarHospede()
        {
            string nome, genero, profissao;
            int idade;

            Console.Write("Nome:");
            nome = Console.ReadLine();

            Console.Write("Idade:");
            idade = int.Parse(Console.ReadLine());

            Console.Write("Genero:");
            genero = Console.ReadLine();

            Console.Write("Profissao:");
            profissao = Console.ReadLine();

            pessoas.Add(new Pessoa(nome, idade, genero, profissao));
        }
        static void EncontrarHospede()
        {
            Console.WriteLine("Nome do Hóspede:");
            string nomeProcurado = Console.ReadLine();
            int indicePessoaEncontrada = pessoas.FindIndex(p => p.GetNome() == nomeProcurado);

            // Verifique se a pessoa foi encontrada
            if (indicePessoaEncontrada != -1)
            {
                pessoas[indicePessoaEncontrada].ListarInformações();
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada.");
                
            }
        }

        static void CadastrarSuite()
        {
            int capacidade;
            double valorDiaria;

            Console.WriteLine("Capacidade:");
            capacidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor Diaria:");
            valorDiaria = double.Parse(Console.ReadLine());

            suites.Add(new Suite(capacidade, valorDiaria));
        }

        static void EncontrarSuite()
        {
            Console.WriteLine("Numero da suite:");
            int suiteProcurada = int.Parse(Console.ReadLine());          

            // Verifique se a pessoa foi encontrada
            if (suiteProcurada > suites.Count || suiteProcurada < 1)
            {
                Console.WriteLine("Suite não existe.");
            }
            else
            {
                suites[suiteProcurada].ListarInformações();

            }
        }

        static void EncontrarReserva()
        {
            Console.WriteLine("Numero da reserva:");
            int reservaProcurada = int.Parse(Console.ReadLine());

            // Verifique se a pessoa foi encontrada
            if (reservaProcurada > reservas.Count || reservaProcurada < 1)
            {
                Console.WriteLine("Suite não existe.");
            }
            else
            {
                suites[reservaProcurada].ListarInformações();

            }
        }

        static void CadastrarReserva()
        {
            if (suites.Count == 0)
            {
                Console.WriteLine("Não existem suíte.");
                return;
            }
            Console.WriteLine("Numero da Suite:");
            int suite = int.Parse(Console.ReadLine());

            if (suite < 1 || suite > suites.Count)
            {
               Console.WriteLine("Não existe essa suíte no nosso Hotel.");
                return;
            }

           
            List<Pessoa> hospedes = new List<Pessoa>();

            Console.WriteLine("Quantos hóspedes?");
            int numeroHospedes;
            while (!int.TryParse(Console.ReadLine(), out numeroHospedes) || numeroHospedes < 1)
            {
                Console.WriteLine("Número de hóspedes inválido. Digite novamente.");
            }

            
            for (int i = 1; i <= numeroHospedes; i++)
            {
                Console.WriteLine($"Nome do Hóspede {i}:");
                string nomeProcurado = Console.ReadLine();

                
                int indicePessoaEncontrada = pessoas.FindIndex(p => p.GetNome() == nomeProcurado);
                if (indicePessoaEncontrada != -1)
                {
                    
                    hospedes.Add(pessoas[indicePessoaEncontrada]);
                }
                else
                {
                    
                    Console.WriteLine("Hóspede não encontrado. Vamos cadastrar...");

                    
                    CadastrarHospede();

                    
                    indicePessoaEncontrada = pessoas.FindIndex(p => p.GetNome() == nomeProcurado);
                    if (indicePessoaEncontrada != -1)
                    {
                        
                        hospedes.Add(pessoas[indicePessoaEncontrada]);
                    }
                    else
                    {
                        Console.WriteLine("Houve um problema ao cadastrar o hóspede.");
                    }
                }
            }

            
            Console.WriteLine("Data de Início da Reserva (dd/MM/yyyy):");
            DateTime dataInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Data de Fim da Reserva (dd/MM/yyyy):");
            DateTime dataFim = DateTime.Parse(Console.ReadLine());

            try
            {
                Reserva reserva = new Reserva(hospedes, suites[suite-1], dataInicio, dataFim);
                reservas.Add(reserva);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro ao criar reserva: " + ex.Message);
                
            }

            
            
        }


        static int ObterEscolhaUsuario()
        {
            int escolha;
            Console.Write("Escolha uma opção: ");
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                Console.Write("Escolha uma opção: ");
            }
            return escolha;
        }
    }
}
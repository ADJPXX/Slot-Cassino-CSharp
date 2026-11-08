# Slot Cassino

Jogo de caça-níquel executado no terminal, desenvolvido em C# com .NET 10. O jogador adiciona créditos à carteira, escolhe o valor da aposta e gira três rolos. O prêmio é pago quando os três símbolos sorteados são iguais.

## Requisitos

- .NET SDK 10.0 ou superior.
- Terminal compatível com entrada pelo teclado.

O projeto não usa pacotes externos.

## Executar

Na raiz do repositório, execute:

```powershell
dotnet run --project .\Slot_cassino\Slot_cassino.csproj
```

Também é possível abrir `Slot_cassino.sln` em uma IDE compatível com projetos .NET.

## Como jogar

1. No menu, selecione `1` para iniciar. A carteira começa com saldo zero.
2. Informe um valor inteiro positivo para adicionar à carteira. Digite `0` para voltar ao menu.
3. Informe uma aposta inteira, maior que zero e dentro do saldo disponível. Digite `0` para voltar à tela de depósito.
4. Pressione Enter para girar. O programa mantém a aposta selecionada nos giros seguintes; pressione `S` para voltar à tela de aposta.
5. Para encerrar, volte ao menu e selecione `0`.

O código atual trata qualquer tecla diferente de `S` como um giro, embora a tela solicite Enter.

## Símbolos e prêmios

Os três rolos sorteiam independentemente entre os cinco símbolos abaixo. Cada símbolo tem a mesma chance de aparecer em cada rolo.

| Combinação nos três rolos | Multiplicador |
| --- | ---: |
| `BAR` – `BAR` – `BAR` | 2x |
| `BAR BAR` – `BAR BAR` – `BAR BAR` | 4x |
| `BAR BAR BAR` – `BAR BAR BAR` – `BAR BAR BAR` | 6x |
| `BOOST` – `BOOST` – `BOOST` | 10x |
| `777` – `777` – `777` | 50x |

Somente três símbolos iguais pagam prêmio. A aposta é debitada antes do giro; em uma combinação premiada, o saldo recebe o valor da aposta multiplicado pelo multiplicador correspondente.

## Estrutura do projeto

```text
Slot_cassino.sln
Slot_cassino/
├── Estado.cs             # Estados do fluxo do jogo
├── Jogador.cs            # Nome, saldo, depósitos e débito de apostas
├── Program.cs            # Menu, entrada, sorteios e pagamento de prêmios
└── Slot_cassino.csproj   # Aplicação de console para .NET 10
.github/workflows/
└── release.yml            # Publicação manual de executável para Windows x64
```

## Publicação no GitHub Actions

O workflow `Build Release` é iniciado manualmente (`workflow_dispatch`). Ele restaura e publica o projeto como um executável Windows x64 autocontido e de arquivo único, e cria uma release com o artefato `Slot_cassino.exe`.

## Limitações conhecidas

- O nome do jogador está fixado no código e o saldo não é salvo entre execuções.
- Valores de saldo e aposta são inteiros; não há casas decimais.
- O jogador é criado com saldo inicial `-100000`, mas o construtor aceita apenas saldos positivos. Na prática, a carteira começa em zero.
- Se uma aposta repetida ficar maior que o saldo restante, o débito é ignorado, mas o giro ainda acontece. Assim, esse giro pode conceder prêmio sem que a aposta tenha sido debitada.
- O saldo usa `int`, sem proteção contra estouro em depósitos ou pagamentos muito altos.

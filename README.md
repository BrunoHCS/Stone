# Stone

## Endpoints

### POST
* Criar Conta:
**/api/bank/criarconta**

> BODY
>{
>    "NumeroConta": 1234
>}
 
* Depósito:
**/api/bank/deposito**

> BODY
>{
>    "NumeroConta": 1234,
>    "Valor": 150
>}

### GET
* Saque:
**/api/bank/saque**
> BODY
>{
>    "NumeroConta": 1234,
>    "Valor": 50
>}

* Extrato:
**/api/bank/extrato**
> BODY
>{
>    "NumeroConta": 1234
>}

### PUT
* Transferir:
**/api/bank/transferir**
> BODY
>{
>    "ContaOrigem": 1234,
>    "ContaDestino": 2345,
>    "Valor": 50
>}




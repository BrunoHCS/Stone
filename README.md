# API de Conta Bancária

## Endpoints

### POST
* Criar Conta:
**/api/bank/criarconta**
```
{
    "NumeroConta": 1234
}
```
 
* Deposito:
**/api/bank/deposito**
```
{
    "NumeroConta": 1234,
    "Valor": 150
}
```

### GET
* Saque:
**/api/bank/saque**
```
{
    "NumeroConta": 1234,
    "Valor": 50
}
```

* Extrato:
**/api/bank/extrato**
```
{
    "NumeroConta": 1234
}
```

### PUT
* Transferir:
**/api/bank/transferir**
```
{
    "ContaOrigem": 1234,
    "ContaDestino": 2345,
    "Valor": 50
}
```




# Calculadora_Comissao_WebAPI

## Objetivo
Projeto desenvolvido como meio de avaliação para o teste da empresa TG4.

## Resumo
O Projeto foi concebido em .NET 6 e permite a consulta de comissão de vendas por meio de uma lista qualquer de vendas.
O Projeto foi construido com o FluentValidation para a validação dos modelos de entrada da aplicação, logo quando falta qualquer propriedade ou ela é nula a api devolve um erro 400 - BadRequest.
Os payloads de entrada e saída foram concebidos de forma a serem exatamente iguais os do exemplo disponibilizado, inclusive seus tipo, conversões e precisão.
Não foi criado uma espécie de repositório em memória por não achar que faz sentido armazenar esses valores tanto de entrada(pedidos) quando de saida(comissões).
A Api não foi construida com nenhuma arquitetura de projeto devido a seu nível de complexidade.
A construção da Api conta com fatores interessantes como Inversão de controle através de inversão de dependência entre outros fatores.


## Observações 
### Alteração Payload Inicial
Payload Inicial foi alterado pois a forma com que as apis leem os dados não permite o recebimento de dados da coluna de valor 

```
{"pedidos": [
{ "vendedor": 1, "data": "2022-03-01", "valor"=500.34 },
{ "vendedor": 1, "data": "2022-03-01", "valor"=1000.22 },
{ "vendedor": 1, "data": "2022-03-01", "valor"=100.35 },
{ "vendedor": 1, "data": "2022-03-01", "valor"=22.34 },
{ "vendedor": 1, "data": "2022-04-01", "valor"=5000.34 },
{ "vendedor": 2, "data": "2022-03-01", "valor"=2000.34 },
{ "vendedor": 2, "data": "2022-04-01", "valor"=3000.34 },
]}

```

foi alterado para: 

```
{"pedidos": [
{ "vendedor": 1, "data": "2022-03-01", "valor":500.34 },
{ "vendedor": 1, "data": "2022-03-01", "valor":1000.22 },
{ "vendedor": 1, "data": "2022-03-01", "valor":100.35 },
{ "vendedor": 1, "data": "2022-03-01", "valor":22.34 },
{ "vendedor": 1, "data": "2022-04-01", "valor":5000.34 },
{ "vendedor": 2, "data": "2022-03-01", "valor":2000.34 },
{ "vendedor": 2, "data": "2022-04-01", "valor":3000.34 }
]}

```

### Inserção de validação no mês 7 das metas
Ao criar o dicionário que gera as metas por mês, percebi que estava faltando o valor referente ao mes 7, então dentro do código gerei uma validação que caso ocorra de o mês 7 ser passado não seria retornado nenhum valor de desconto








# Simulador de Caixa Eletrônico Seguro em C#

Este projeto é um simulador de caixa eletrônico desenvolvido em C# usando o Visual Studio Code. O simulador incorpora práticas recomendadas de segurança de autenticação, incluindo o uso de hash para senhas, salting e métodos seguros de comparação.


### Melhorias de Segurança Implementadas

1. Hash para Senhas:
   - As senhas são armazenadas em formato de hash usando o algoritmo SHA-256.

2. Adição de Sal às Senhas:
   - Cada usuário tem um "sal" aleatório exclusivo, adicionado à senha antes de gerar o hash.

3. Método Seguro para Comparar Senhas:
   - A comparação de senhas é feita de forma segura, garantindo que mesmo se duas senhas forem iguais, seus hashes não serão.

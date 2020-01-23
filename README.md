# Relatório do 3º Projeto de Linguagens de Programação II

## Anastasis

**Projeto realizado por:**
- [Guilhereme Saturno, a21700118](https://github.com/guisaturno)
- [Lucas Viana, a21805095](https://github.com/LucasViana18)
- [Rita Saraiva, a21807278](https://github.com/RitaSaraiva)

## Indicação do trabalho realizado pelos membros do grupo:

- Guilherme Saturno:
  - Implementação das mecanicas _IntangibleForm_ e _LampLight_;
  - Realização de parte do relatório, em conjunto com Rita Saraiva e Lucas
  Viana.

- Lucas Viana:
  - Implementação do moviemnto do personagem;
  - Implementação do puzzle;
  - Implementação dos audios;
  - Realização de parte do relatório, em conjunto com Rita Saraiva e Guilherme Saturno.

- Rita Saraiva:
  - Implementação dos menus;
  - Implementação da gravidade;
  - _Doxygen_;
  - Diagrama UML;
  - Realização do relatório, com Lucas Viana e Guilherme Saturno.

## Descrição da solução

### Arquitetura da solução:

De forma a organizar o código decidimos optar por isolar responsabilidades, limitando ao máximo interações desnecessárias entre os mesmos devido a simplicidade do projeto. Tendo isso em vista foram criados os scripts `Player`, `PlayerInteractions`, `LampLight` e `IntangibleForm` para o objeto do jogador, `CameraMovement` para a camera e `Item`, `Interactive`, `ColisionTree` e `ColisionTreeAfter` para os objetos e por fim para gestão de sistemas foram utilizados `Dialogue`, `AudioManager` e `CanvasManager`.

Este código faz o uso de _design patterns_ tais como 
_Iterator pattern_ ao percorrer listas e arrays, _Facade pattern_, e _Mediator pattern_ através da classe `Player` que é responsável por todos os inputs e ações do jogador.

### Diagrama UML:

![DiagramaUML](diagramaUML.png)

### Referências:

1. Foi utilizada a [API do .NET](https://docs.microsoft.com/en-us/dotnet/api/), [API do UNITY](https://docs.unity3d.com/ScriptReference/) e 
[StackOverFlow](https://stackoverflow.com/);
2. Foi utilizado como referência os videos do Brackeys sobre [menu](https://www.youtube.com/watch?v=zc8ac_qUXQY) e [pause](https://www.youtube.com/watch?v=JivuXdrIHK0);

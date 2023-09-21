# Hyperstellar Happy Corporate Science Space Station

Jeu de plateau de stratégie en C# réalisé pour mon IUT uniquement fait en C# avec .NET Windows Form

## Présentation du projet

Ce projet est un jeu de plateau réalisé pour l'IUT, les règles du jeu nous avont été donné, nous devions alors réaliser le jeu en C# avec .NET Windows Form.

Nous avions 1 mois pour le faire, nous étions 4 sur le projet.

## Présentation du jeu

Hyperstellar Happy Corporate Science Space Station est un jeu de plateau dans lequel chaque joueur est un milliardaire visionnaire et novateur, qui a délaissé la vie terrestre pour se consacrer à l’exploration spatiale au sein d’une station spatiale de recherche scientifique privée pour l’avancée générale du genre humain. <br><br>Cette mission nécessite des capitaux immenses, et donc la collaboration de plusieurs milliardaires partageant la même aspiration. <br>Mais chacun souhaite être le plus grand scientifique
visionnaire novateur et devenir le maître incontesté de la station, et donc à terme de l’univers entier...<br>

## Règles du jeu

<!--Faire un tableau en md-->
| Séquence | Que se passe-t-il |
| :---: | :---: |
| Partie | Une partie de jeu, se terminant à la fin de la révolution dans laquelle un joueur gagne. |
| Révolution | Une séquence comportant une phase de placement complète,<br> une phase d’action complète,<br>  une phase d’entretien complète.<br>  À la fin d’une révolution, une autre commence, sauf si la partie est terminée |
| Phase de placement | Une phase dans laquelle se déroulent autant de rotations de placement que nécessaire pour placer les pions de chaque joueur. Après cette phase, une phase d’action est lancée |
| Rotation de placement | Une rotation est un tour de table dans l’ordre des joueurs : chaque joueur place un pion, chacun à son tour. Les rotations de placement s’enchaînent jusqu’à ce qu’il n’y ait plus de pions à placer. |
| Phase d’action | Une phase dans laquelle se déroulent autant de rotations d’action que nécessaire pour que chaque joueur ait joué. Après cette phase, une phase d’entretien est lancée |
| Rotation d’action | Une rotation d’action concerne un secteur, chaque joueur qui dispose de pions dans le secteur les retire et les replace sur le moyeu de la station en accomplissant l’action du secteur, dans l’ordre des joueurs. Quand cette rotation est terminée, on passe à celle du secteur suivant. |
| Action | Accomplir une action pour un joueur, pour un secteur, et replacer les pions sur le moyeu central avant de passer à l’action suivante. |
| Phase d’entretien | Chaque joueur paie l’entretien de ses pions. S’il ne peut plus payer cet entretien, il perd un pion (et un seul). S’il n’a plus de pion, il perd la partie. L’entretien et ses conséquences sont gérés en une seule fois pour chaque joueur dans l’ordre des joueurs. La fin de cette phase met fin à la révolution en cours |

### Début de partie :

Deux à quatre joueurs prennent place. <br>Chaque joueur s’assied autour de la table, ils jouent dans l’ordre de leur placement (joueur en haut, puis à droite, puis en bas, puis à gauche). <br>Chaque joueur reçoit 10 *jetons énergie* et 10 *jetons eau* qu’ils placent devant eux, dans leur stock personnel (visible par tous en permanence).<br> Deux *pions chercheur* de la couleur de chaque joueur sont placés au centre du plateau (sur le moyeu de la station), les huit autres sont remis dans le stock du jeu. Les *cartes science* sont mélangées et posées en une pile.

### Déroulement d’une révolution - phase de placement :

Les joueurs jouent chacun à leur tour, du premier au dernier dans une **rotation de placement** (tour de table). <br>Chaque joueur prend un **pion** (chercheur) de **sa couleur** du centre du plateau (le moyeu) pour le poser dans un emplacement d’action **libre** de son choix avant que le joueur suivant fasse de même. <br>Si un des joueurs ne dispose plus de pions au centre du plateau et que la phase de
placement continue, il récupère **un** *jeton énergie* au lieu de placer un pion.<br> Une nouvelle rotation de placement est lancée s’il des pions peuvent au centre du plateau.<br> La phase de placement s’interrompt immédiatement s’il n’y a plus d’emplacements d’action libres, les pions non placés restent au centre du plateau





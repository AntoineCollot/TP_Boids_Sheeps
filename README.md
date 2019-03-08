# TPBoids_Sheeps

## Objectif

L'objectif de cet exercice est d'implémenter l'algorithme décrit dans l'article suivant :
http://www.csc.kth.se/utbildning/kth/kurser/DD143X/dkand13/Group9Petter/report/Martin.Barksten.David.Rydberg.report.pdf

Cet article propose une variante de l'algorithme de Reynolds sur le comportement d'une nuée d'oiseau ou d'un troupeau. Le but est d'adapter cet algorithme à un troupeau de mouton.

![alt text](Resultat.gif "Resultat")

## 1 - Berger

1. Creer un script __*KeyboardControl*__.
1. Ce script doit permettre de déplacer l'objet auquel il est attaché à l'aide du clavier.
1. Appliquer ce script au berger.

## 2 - Chien

1. Creer un script __*MouseControl*__.
1. Ce script doit permettre de déplacer l'objet à l'aide d'un clique de souris. L'objet doit se déplacer graduelement vers l'emplacement cliqué par la souris.
	1. Détecter un clique gauche de la souris
	1. Envoyer un raycast depuis la position du curseur à l'aide de la fonction *Camera.ScreenPointToRay()*.
	1. Récupérer la position touchée dans une variable *target*
	1. Déplacer l'objet graduelement vers *target*.
1. Appliquer ce script au chien.

## 3 - Moutons

Dans le script __*SheepBoid*__ :

1. Implémenter la fonction sigmoid 3.1.
	* Changer la valeur du dénominateur __20__ par __0.3__.
1. Implémenter la fonction de poids 3.2.
1. Implémenter la fonction inverse 3.3.
1. Implémenter la régle de cohésion 3.4.
	* Une liste de tout les moutons est accessible via la variable *SheepHerd.Instance.sheeps*.
	* Bonus : Visualiser le vecteur produit à l'aide d'un *Debug.DrawRay()* de couleur vert.
1. Implémenter la régle de séparation 3.5.
	* Bonus : Visualiser le vecteur produit à l'aide d'un *Debug.DrawRay()* de couleur noir.
1. Implémenter la régle d'alignement 3.6.
	* Remplacer la notion de rayon de __50 pixels__ par une variable __*flightZoneRadius*__ (valeur en annexe).
	* Bonus : Visualiser le vecteur produit à l'aide d'un *Debug.DrawRay()* de couleur jaune.
1. Implémenter la régle de fuite 3.8.
	* Changer la valeur du paramètre __10__ par __2__.
	* Le predateur est accessible dans la variable *predator*.
	* Bonus : Visualiser le vecteur produit à l'aide d'un *Debug.DrawRay()* de couleur rouge.
1. Implémenter la formule 3.9 dans la fonction *Vector3 ApplyRules()*.
	* Bonus : Reprendre les *Debug.DrawRay()* précédents pour leur appliquer les poids de chaque règle.
1. Ajouter une régle d'encloisonement, pour faire en sorte que les moutons restent dans l'enclos.
	* Cette règle est déjà préfaite sous la forme de la fonction *Pen.Instance.RuleEnclosed()*.
	* Donner un poids de __3__ à cette règle.

## 4 - Bonus

1. Proposer une règle supplémentaire qui permette aux moutons d'interagir avec le berger, par exemple une régle d'évitement pour éviter les collisions avec le berger, ou encore une régle de cible, pour permettre aux moutons de suivre le berger.

## Annexe - Valeurs des variables

| Variable             | Value |
|----------------------|-------|
| flightZoneRadius     | 7     |
| weightCohesionBase   | 0.5   |
| weightCohesionFear   | 5     |
| weightSeparationBase | 2     |
| weightSeparationFear | 0     |
| alignementZoneRadius | 3     |
| weightAlignmentBase  | 0.1   |
| weightAlignmentFear  | 1     |
| weightEscape         | 6     |

   M S B A M L   `   `   `  ���� J  FWPF Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_ApplicationWPF_Application      WPF_Application.Coloring   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WPF_Application       � Title$  
Mandelbrot��$��503.913��$��766.495��.��� .+��� -    ��Name$ Terminer��$��Suivant��$��Right=�$��0,0,82,10.4q�$��67��$��Bottom=��� -    ��Name$
 Zoom��$
��Left=�$��23��$��	10,41,0,0q� �� TextWrapping$
 Wrap=�$��0��$	��Top=�$	��224���� -   $ Nbr_itérations��$
��Left=�$��23��$��	10,90,0,0q�$
 Wrap=�$��0��$	��Top=�$	��224���� $
��Left=�$��	10,20,0,0q�$
��Wrap=�$	��Top=�$��35��$
��Zoom���� $
��Left=�$��	10,69,0,0q�$
��Wrap=�$	��Top=�$	��109��$��Nombre d'itérations���� -   $	 Red��$
��Left=�$��23��$��
10,139,0,0q�$
 Wrap=�$��0��$	��Top=�$	��224���� $
��Left=�$��
10,118,0,0q�$
��Wrap=�$	��Top=�$	��109��$��Rouge���� $
��Left=�$��
10,167,0,0q�$
��Wrap=�$	��Top=�$	��109��$
��Vert���� -   $ Green��$
��Left=�$��23��$��
10,188,0,0q�$
 Wrap=�$��0��$	��Top=�$	��224���� $
��Left=�$��
10,216,0,0q�$
��Wrap=�$	��Top=�$	��109��$
��Bleu���� -   $
 Blue��$
��Left=�$��23��$��
10,237,0,0q�$
 Wrap=�$��0��$	��Top=�$	��224���� $
��Left=�$��
10,265,0,0q�$
��Wrap=�$	��Top=�$	��109��$
��Type���� -   $
 type��$
��Left=�$��23��$��
10,286,0,0q�$
 Wrap=�$��0��$	��Top=�$	��224���� $
��Left=�$��
267,41,0,0q�$
��Wrap=�$	��Top=�$	��378��$	��449�� �� TextAlignment$ Justify=��� $�Infos sur les types :�� �� TextDecorations$ 	Underline{��� �� $
�1 : ���� $z�tColoring par defaut, les pixels appartenant a la fractale sont colorés dans la couleur correspondant aux 3 valeurs ���� $�RGB. ���� $�Ces valeurs ���� $�doivent être comprises ���� $�entre 0 et 255���� $�. ���� $=�7Le pixel coloré est un pixel appartenant a la fractale���� $�.���� �� $
�2 : ���� $O�IColoring via EscapeColoring, les points sortant de la fractale sont color���� $�é���� $�s avec une cert���� $
�aine���� $@�: fonction (pouvant etre cos,sin ou autre) prenant en param���� $�è���� $�tre l'iteration de sortie���� $�. ���� $�De plus avec les valeurs ���� $
�RGB ���� $E�?on peut faire varier la part de chaque couleur dans le coloring���� $�. ���� $�Les valeurs int���� $�é���� $<�6ressantes pour les couleurs sont entre 0 exclu et 10 (���� $-�'plus haut, la couleur devient invisible���� $�)���� $�. ���� $,�&Plus la valeur de couleur diminue plus���� $�-���� $�celle ci est visible���� �� $�
3 : Même ���� $�coloring���� $�	 que le 2���� $� mais en noir et blanc���� $�.���� �� $
�4 : ���� $�Coloring dit "n���� $�é���� $�on", nous l'avons invent���� $�é���� $� nous���� $�-���� $�m���� $�ê���� $�me���� $�s���� $1�+. Un pixel sortant de la fractale est color���� $�é���� $!� en fonction du module de z���� $�,���� $� calcul���� $�é���� $� ���� $�à���� $� la derniere it���� $�é���� $�
ration (it���� $�é���� $�ration de sortie ���� $�pour laquelle ���� $	�z d���� $�é���� $�passe le module max impos���� $�é���� $�)���� $�. ���� $�Les valeurs de ���� $
�RGB ���� $E�?permettent de varier la part de chaque couleur dans le coloring���� $�. ���� $�Les valeurs int���� $�é���� $=�7ressantes pour les couleurs sont entre 0 exclu et 100 (���� $,�&plus haut la couleur devient invisible���� $�)���� $�. ���� $2�,Plus la valeur de couleur diminue plus celle���� $�-���� $x�rci est visible. En dessous de 0.5 la couleur devient presque uniforme, la valeur minimale pour garder un effet int���� $�é���� $�ressant est 0.5���� $�.���� �� $�
5 : Même ���� $�coloring���� $�	 que le 4���� $� mais en noir et blanc���� $�.���� �� $
�6 : ���� $�Ce coloring est un degrad���� $�é���� $m�g observable surtout entre le bleu et le vert en fonction de la position du pixel a colorer dans l'image���� $�. ���� $�Le pixel color���� $�é���� $-�' est un pixel appartenant a la fractale���� -   $ Annuler��$��Annuler��$��Right=�$��0,0,10,10.4q�$��67��$��Bottom=�
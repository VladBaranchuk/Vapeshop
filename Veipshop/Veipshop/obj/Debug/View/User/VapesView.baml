   M S B A M L   `   `   `  ����C  ?Veipshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Veipshop.ViewModelVeipshop.ViewModel  5      3clr-namespace:Veipshop.ServiceVeipshop.Service  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType     Veipshop.ViewModel.VapesVM � 	Resources)   #Veipshop.Service.ImagePathConverter   Key � RowDefinitions �� Orientation J� RenderTransformOrigin �� Path  ImagePathConverter �� 	Converter �� StringFormat�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *local clr-namespace:Veipshop.ViewModel  5      *serviceclr-namespace:Veipshop.Service  5      %9  (��       5      *,  +)7  �� 6   "    6    5   
   ��  5      ImagePathConverter  6)   5      .R�5	   
   � $��0,0,10,0q�6    5
      �� 5      $
��237* �6    �� 5      $
��383* �6    .+�5      �� $ 
Horizontal=�6   $��
10,10,0,10q�62   $ 0.5,0.5&�6F   .+�5      �� $	��202��6i   ��6   �� $ 	ProductId�8   6i   �� 5      $ Vertical=�6   $	��542��64   $��0,-1,0,0q�6@   $ 0.5,0.5&�6R   .+�5      �� $
��Wrap=�66   $ 0.5,0.5&�6J   $��50��6j   $��DemiBold"�6v   $��16(�6�   $��	62,0,74,0q�6�   ��6    �� *Name+6�   �� 5      $
��Wrap=�6S   $��16(�6g   $
��Bold"�6u   $��29��6�   $��62,20,332,0q�6�   ��6    �� *Price+$ {0} рублей��6�   �� 5      $��26��6@   $��В корзину��6L   $��62,80,332,0q�6`   ��6   �� *BasketCommand+6`   5      5      �� 5      $��0,10,0,0q�6   $��1��6+   .+�5      �� $
��Wrap=�6   $
��Bold"�60   $��25(�6B   $ 0.5,0.5&�6P   $��40��6p   $��
62,0,676,0q�6|   Характеристики6�   �� 5      $
��Wrap=�6�   $ 0.5,0.5&�6�   $��28��6�   $��	62,0,74,0q�6�   ��6   �� $X RМаксимальная мощность......................................{0}��$ 	PeakPower�6�   5      5      5      5      
   M S B A M L   `   `   `  ����C  ?Veipshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Veipshop.ViewModel.Administrator Veipshop.ViewModel.Administrator  5      3clr-namespace:Veipshop.ServiceVeipshop.Service  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType<    6Veipshop.ViewModel.Administrator.AdministratorOrdersVM � 	Resources-  'Veipshop.Service.CompleteValueConverter   Key)   #Veipshop.Service.ImagePathConverter � RowDefinitions �� Orientation �� SelectedItem K� IsItemsHost �� StringFormat �� Path  CompleteValueConverter �� 	Converter	 �� RelativeSource
 �� Mode �� AncestorType  ImagePathConverter �� TextAlignment�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8local.clr-namespace:Veipshop.ViewModel.Administrator  5      *serviceclr-namespace:Veipshop.Service  5      %k  (��       5      *,  +)7  7  �� 6   "    6    5      ��  5   
   CompleteValueConverter  6)     5   
   ImagePathConverter  6%   5	      .R�5
      �  5   
   �� 5      $��30 �6   �� 5      .+�5   
   � $��30��6   $��0��6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��16(�6   $
��Bold"�6*   Заказы6D   5      5      � 5   
   $��1��6   .+�5      �� $
��Auto=�6   ��. .��5      �� $��Disabled=�6g   $��0��6�   $
��1024��6�   ��6   �� *	Baskets+ 6>   �� *SelectedProduct+��5      �� 5      .R�5      �  . 6(   5      ��5      �� 5      .R�5      �� .+�5   "   �� $��32��6)   $
��1000��65   
���P��._�5    &   �� $��Center=�61   $ 
Horizontal=�6L   $
��20,0q�6e   .+�5!   .   �� ��68   �� $ Заказ No:{0}��$ 	basket_id��� 5"   .   $��600, 0, 30, 0q�68   ��6O   �� $ confirm�8   �� 5#   .   $��70��65   $��30��6@   ��6L   �� 	 �� $
 FindAncestor=�" �$ DataContext.OrderCommand���6�   �� .��6�   Готово6�   5$   +   5%   #   �� 5&   "   $��Disabled=�6s   $��0��6�   $
��1024��6�   ��6*   �� *	Product+ 6J   �� *SelectedProduct+��5'   &   �� 5(   *   .R�5)   .   �  . 68   5*   +   ��5,   &   �� 5-   *   .R�5.   .   �� $ Vertical=�69   $	��190��6P   $��25q�6\   .+�5/   2   �� $	��200��6�   ��68   �� $ 
product_id�8  6�   �� 50   2   $
��Wrap=�6W   $ Center=�6k   $��54��6�   $	��7,0q�6�   ��6<   �� $
 name�6�   �� 51   2   $
��Wrap=�6s   $��16(�6�   $
��Bold"�6�   $ Center=�6�   $��26��6�   $��10,0, 0, 32q�6�   $	��170��6�   ��6<   �� $ {0} рублей��$ price�6�   52   /   53   +   55   #   56      57      59      5:      5;      5<      5=      5>      
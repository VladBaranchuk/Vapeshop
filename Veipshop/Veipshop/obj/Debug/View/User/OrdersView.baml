   M S B A M L   `   `   `  ����C  ?Veipshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Veipshop.ViewModelVeipshop.ViewModel  5      3clr-namespace:Veipshop.ServiceVeipshop.Service  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType!    Veipshop.ViewModel.OrdersVM � 	Resources-  'Veipshop.Service.CompleteValueConverter   Key)   #Veipshop.Service.ImagePathConverter � RowDefinitions �� Orientation �� SelectedItem K� IsItemsHost �� StringFormat �� Path  CompleteValueConverter �� 	Converter  ImagePathConverter	 �� TextAlignment�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *local clr-namespace:Veipshop.ViewModel  5      *serviceclr-namespace:Veipshop.Service  5      %�  (��       5      *,  +)7  7  �� 6   "    6    5   
   ��  5      CompleteValueConverter  6-     5      ImagePathConverter  6)   5	      .R�5
   
   �  5      �� 5      $��30 �6    �� 5      .+�5      � $��30��6   $��0��6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��16(�6    $
��Bold"�6.   Заказы6H   5      5      � 5      $��1��6   .+�5      �� $
��Auto=�6   ��. .��5      �� $��Disabled=�6g   $��0��6�   $
��1024��6�   ��6   �� *	Baskets+ 6>   �� *SelectedProduct+��5      �� 5      .R�5   "   �  . 6,   5      ��5      �� 5      .R�5   "   �� .+�5   &   �� $��32��6-   $
��1000��69   
���P��._�5    *   �� $��Center=�65   $ 
Horizontal=�6P   $
��20,0q�6i   .+�5!   .   �� ��68   �� $ Заказ No:{0}��$ 	basket_id��� 5"   .   $��700, 0, 0, 0q�68   ��6N   �� $ confirm�8   5#   +   5$   '   �� 5%   &   $��Disabled=�6w   $��0��6�   $
��1024��6�   ��6.   �� *	Product+ 6N   �� *SelectedProduct+��5&   *   �� 5'   .   .R�5(   2   �  . 6<   5)   /   ��5+   *   �� 5,   .   .R�5-   2   �� $ Vertical=�6=   $	��190��6T   $��25q�6`   .+�5.   6   �� $	��200��6�   ��6<   �� $ 
product_id�8  6�   �� 5/   6   $
��Wrap=�6[   $	 Center=�6o   $��54��6�   $	��7,0q�6�   ��6@   �� $
 name�6�   �� 50   6   $
��Wrap=�6w   $��16(�6�   $
��Bold"�6�   $	 Center=�6�   $��26��6�   $��10,0, 0, 32q�6�   $	��170��6�   ��6@   �� $ {0} рублей��$ price�6�   51   3   52   /   54   '   55   #   56      58      59      5:      5;      5<      5=      
   M S B A M L   `   `   `  ����C  ?Veipshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Veipshop.ViewModelVeipshop.ViewModel  5      3clr-namespace:Veipshop.ServiceVeipshop.Service  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType!    Veipshop.ViewModel.BasketVM � 	Resources)   #Veipshop.Service.ImagePathConverter   Key � RowDefinitions �� Orientation �� SelectedItem K� IsItemsHost �� Path  ImagePathConverter �� 	Converter �� TextAlignment	 �� StringFormat
 �� RelativeSource �� Mode �� AncestorType�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *local clr-namespace:Veipshop.ViewModel  5      *serviceclr-namespace:Veipshop.Service  5      %�  (��       5      *,  +)7  �� 6   "    6    5   
   ��  5      ImagePathConverter  6)   5      .R�5	   
   �  5
      �� 5      $��30 �6    �� 5      .+�5      � $��30��6   $��0��6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��16(�6    $
��Bold"�6.   Корзина6I   �� 5      $	��100��6@   $��30��6L   $��850,0, 0, 0q�6X   ��6   �� *ToOrderCommand+.��6m   Заказать6w   5      5      � 5      $��1��6   .+�5      �� $��Disabled=�6d   $��0��6�   $
��1024��6�   ��6   �� *
Products+ 6;   �� *SelectedProduct+��5      �� 5      .R�5      �  . 6(   5      ��5      �� 5      .R�5      �� $ Vertical=�6)   $	��190��6@   $��25q�6L   .+�5   "   �� $	��200��6z   ��6(   �� $ 
product_id�8   6z   �� 5   "   $
��Wrap=�6G   $ Center=�6[   $��54��6r   $	��7,0q�6~   ��6,   �� $
 name�6~   �� 5    "   $
��Wrap=�6c   $��16(�6w   $
��Bold"�6�   $ Center=�6�   $��26��6�   $
��10,0q�6�   $	��170��6�   ��6,   �� $	 {0} рублей��$ price�6�   �� 5!   "   $��32��5#   )   $
��28,0q�5$   )   ��5!   )   �� 
 �� $ FindAncestor=�" �$ DataContext.BasketCommand���5"   )   �� .��5$   7   $"Удалить из корзины6K   5%      5&      5(      5)      5*      5+      5,      
   M S B A M L   `   `   `  ����C  ?Veipshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Veipshop.ViewModel.Administrator Veipshop.ViewModel.Administrator  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      3clr-namespace:Veipshop.ServiceVeipshop.Service  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType=    7Veipshop.ViewModel.Administrator.AdministratorCatalogVM � 	Resources)   #Veipshop.Service.ImagePathConverter   Key � RowDefinitions �� SelectedItem K� IsItemsHost �� Orientation �� Path  ImagePathConverter �� 	Converter �� TextAlignment	 �� StringFormat
 �� RelativeSource �� Mode �� AncestorType.  (System.Windows.Interactivity.Interaction   Triggers/  )System.Windows.Interactivity.EventTrigger   	EventName.  (System.Windows.Interactivity.TriggerBase   Actions6  0System.Windows.Interactivity.InvokeCommandAction   Command   CommandParameter�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8local.clr-namespace:Veipshop.ViewModel.Administrator  5      ViPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      *serviceclr-namespace:Veipshop.Service  5      %�  (��       5      *,  +)7  �� 6   "    6    5   
   ��  5      ImagePathConverter  6)   5	      .R�5
   
   �  5      �� 5      $��30 �6    �� 5      .+�5      � $��30��6   $��0��6   .+�5      �� $��16(�69   $
��Bold"�6G   ��6   �� *SectionName+6G   5      � 5      $��1��6   .+�5      �� $��Disabled=�6d   $��0��6�   $
��1024��6�   ��6   �� *
Products+ 6;   �� *SelectedProduct+��5      �� 5      .R�5      �  . 6(   5      ��5      �� 5      .R�5      �� $ Vertical=�6)   $	��190��6@   $��25q�6L   .+�5   "   �� $	��200��6z   ��6(   �� $ 
product_id�8   6z   �� 5   "   $
��Wrap=�6G   $ Center=�6[   $��54��6r   $	��7,0q�6~   ��6,   �� $
 name�6~   �� 5   "   $
��Wrap=�6c   $��16(�6w   $
��Bold"�6�   $ Center=�6�   $��26��6�   $
��10,0q�6�   $	��170��6�   ��6,   �� $	 {0} рублей��$ price�6�   �� 5   "   $��32��5!   )   $
��28,0q�5"   )   ��5   )   �� 
 �� $ FindAncestor=�" �$ DataContext.DeleteCommand���5    )   �� .��5"   7   Удалить6@   5#      5$       5&        5'      $ SelectionChanged��6)   . 5(         5)   -   �� 
 �� $ FindAncestor=�" �$ DataContext.ClickCommand� 5*   -   �� 
 �� $ FindAncestor=�" �$! DataContext.SelectedProduct�5+      5-      5.      5/      50      51      
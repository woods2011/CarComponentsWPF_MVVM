   M S B A M L   `   `   `  ����K  GCarComponentsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CarComponentsWPF.ViewsCarComponentsWPF.Views  5      I)clr-namespace:CarComponentsWPF.ViewModelsCarComponentsWPF.ViewModels  5      4    .CarComponentsWPF.Views.CreateComponentTypeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CarComponentsWPF.Views     5      @
viewmodels)clr-namespace:CarComponentsWPF.ViewModels     5      
�������  � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   ��6&   �� *MessageViewModel+y�5      �� *MessageViewModel.HasMessage+ �� 	Converter# [  � 5    
   $��1��6   $��0,0,0,10q�6   $
��Left=�6.   $	��Top=�6I    5!      �� 5"      �� 5#       � ColumnDefinitions 5%      �� 5&      $
��auto �6#   �� 5'      .+�5*      �� $
��Left=�6   $	��0,5q�6/   $��0��6<   $��0��6I   $��2��6Y   $C��=Добавить новый тип комплектующей��6m   $
��Bold"�6�   $��16(�6�   �� 5,      $��1��6   $��0��6!   $��Name:��61   $��16(�6A   �� 5-      $��1��6   $��1��6#   $	��150��63   $	��200��6B   $
��Left=�6Q   $��16(�50      ��5.      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  � ToolTip 5/      �� *ErrorCollection[Name]+50      51      �� 53   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��0,10,0,0q�6;   $��Right=�6M   $��Bottom=�6i   .+�54      ��  ^� ShowOnDisabled . $��Создать��55   T   $��0,0,5,0q�56      $��14(�6&   ��54      �� *CreateEntityCommand+$ PropertyChanged=� 55      �� *Error+56   &   �� 57      $N��HВернуться к списку типов комплектующих��58      $��14(�6F   ��57      �� *BackToListEntitiesCommand+$ PropertyChanged=�58   F   59      5<      5>      
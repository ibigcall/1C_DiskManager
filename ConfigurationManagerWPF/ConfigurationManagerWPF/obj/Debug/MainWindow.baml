   M S B A M L   `   `   `  ����R  NConfigurationManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ConfigurationManagerWPFConfigurationManagerWPF  5   	   (    "ConfigurationManagerWPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ConfigurationManagerWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��0.9* �6   .+�5   
   �� $1��+Локальные конфигурации��6   $��0��62   $��0��6?   $��Center=�6O   6n   �� 5   
   $.��(Конфигурации на диске��6   $��0��61   $��1��6>   $��Center=�6N   6m   �� 5   
   -   5        $��ConfigurationsListBox��5      $��1��6[   $��1��6k   ��6/   ��  �� Path$ Configurations� � ContextMenu 5      �� 5      .@�5      m� -   5        $
��Copy��5      6<   m� 5      -   5        $��Install��5      6H   5      ��5      �� 5      .R�5       �� $��0��6!   $��5q�61   .+�5!      �� $��10(�6$   $��Right=�6S   ��62   �� $ 
UpdOrSetup�6S   �� 5"      $��16(�6$   $��Center=�6M   ��62   �� $
 Name�6M   �� 5#      $��16(�6$   $��Center=�6P   ��62   �� $ Version�6P   5$      5%      5'      �� 5(   
   -   5        $��ConfigurationsListBox3��5(      $��0��6a   $��1��6q   ��60   �� $ LocalConfigurations� 5)      �� 5*      .@�5+      m� -   5        $��Install��5+      6N   m� 5,      -   5        $��Delete��5,      6F   5-      ��5/      �� 50      .R�51      �� $��0��6!   $��5q�61   .+�52      �� $��10(�6$   $��Right=�6S   ��62   �� $ 
UpdOrSetup�6S   �� 53      $��16(�6$   $��Center=�6M   ��62   �� $
 Name�6M   �� 54      $��16(�6$   $��Center=�6P   ��62   �� $ Version�6P   55      56      58      �� 59   
   -   5        $��	ButtonBox��59      $��2��6$   $��1��64   .@�5:      �� -   5        $��ChooseFolderButton��5:      .��6A   97Выбрать папку для коипрования6`   �� 5;      -	   5        $��LocalFolderPath��5;      6/   �� 5<      -
   5        $��CopyAll��5<      .��66   Копировать все6F   5=      5>      5?      
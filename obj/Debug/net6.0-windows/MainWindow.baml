   M S B A M L   `   `   `  ����  FlightTracker!    FlightTrackerWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Flight Tracker��5   	   $	��450��6    $	��800��6-   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0 0 0 10q�6.   .+�5      �� $��	Latitude:��6   $��Center=�6(   �� 5      -   5         ��Name$ LatitudeInput��5      $��80��6-   $��5q�68   �� 5      $��
Longitude:��6   $��Center=�6)   �� 5      -   5        $ LongitudeInput��5      $��80��6.   $��5q�69   �� 5      $��Radius (km):��6   $��Center=�6+   �� 5      -   5        $ RadiusInput��5      $��60��6+   $��5q�66   $��50��6A   �� 5      -   5        $��Fetch Flights��5      $
��10 0q�6H   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ FlightsGrid��5      $��1��6(      AutoGenerateColumns$ False��65      
IsReadOnly$
 True��6Q      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Callsign��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *
Callsign+6T     5      $ Origin��6%   $	 * 6P   
 65   �� *Origin+6P     5      $ Destination��6%   $	 * 6Z   
 6:   �� *Destination+6Z     5      $ Altitude (ft)��6%   $	 * 6Y   
 6<   �� *
Altitude+6Y     5      $ Speed (kts)��6%   $	 * 6T   
 6:   �� *Speed+6T   5      5       5!      
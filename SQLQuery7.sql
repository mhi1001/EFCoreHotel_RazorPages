--select Booking.Booking_id, Booking.Date_From, Booking.Date_To, Guest.Name, Guest.Address 
--SELECT * FROM Room where Hotel_No = 
--SELECT Guest.Name, Guest.Address, Guest.Guest_No 
--FROM Guest, Booking, Hotel 
--where Guest.Guest_No = Booking.Guest_No 
--AND Booking.Hotel_No = Hotel.Hotel_No
--AND Hotel.Name = 'Prindsen'
--AND Booking.Date_From <= 2011-02-14 
--AND Booking.Date_To >= 2011-02-14

SELECT Guest.Name, Guest.Address, Guest.Guest_No 
                            FROM Guest, Booking, Hotel 
                            where Guest.Guest_No = Booking.Guest_No 
                            AND Booking.Hotel_No = Hotel.Hotel_No
                            AND Hotel.Name = 'Prindsen'
                            AND Booking.Date_From <= '14/02/2011 00:00:00' 
                            AND Booking.Date_To >= '14/02/2011 00:00:00' 




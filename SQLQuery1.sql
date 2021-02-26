
--SELECT SUM(Price) 
--FROM Booking, Room, Hotel
--WHERE (Booking.Date_From <= '2011/02/14'
--AND Booking.Date_To >= '2011/02/14')
--AND Room.Hotel_No = Hotel.Hotel_No
--AND Room.Hotel_No = Booking.Hotel_No
--AND Room.Room_No = Booking.Room_No
--AND Hotel.Name = 'Prindsen'

--SELECT SUM(Price) 
--                        FROM Booking, Room, Hotel
--                        WHERE (Booking.Date_From <= '2011/02/14'
--                        AND Booking.Date_To >= '2011/02/14')
--                        AND Room.Hotel_No = Hotel.Hotel_No
--                        AND Room.Hotel_No = Booking.Hotel_No
--                        AND Room.Room_No = Booking.Room_No
--                        AND Hotel.Name = 'Discount'
--COUNT(Booking.Booking_id)

--SELECT Hotel.Name, COUNT(Booking.Booking_id)
--FROM Hotel, Booking
--WHERE Hotel.Hotel_No = 6
--AND Booking.Date_From <= '2011/03/31'
--AND Booking.Date_To >= '2011/03/01'
--GROUP BY Hotel.Name

--select Booking.Booking_id, Booking.Date_From, Booking.Date_To, Guest.Name, Guest.Address 
--FROM Booking, Guest 
--WHERE Booking.Guest_No = Guest.Guest_No 
--AND Booking.Room_No = 1

select Booking.Booking_id, Booking.Date_From, Booking.Date_To, Guest.Name, Guest.Address
FROM Booking, Guest
WHERE Guest.Guest_No = Booking.Guest_No
AND Booking.Room_No = 11






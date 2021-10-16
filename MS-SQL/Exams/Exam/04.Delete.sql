
ALTER TABLE Clients
ADD CONSTRAINT fk_AddressId
    FOREIGN KEY (AddressId)
    REFERENCES Addresses (Id)
    ON DELETE SET NULL

DELETE FROM Addresses
WHERE LEFT(Country, 1) = 'C'

select * from sys.foreign_keys
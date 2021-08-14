CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters NVARCHAR(30), @word NVARCHAR(30))
RETURNS BIT
AS
BEGIN
    DECLARE @I INT = 1;
    WHILE (@I <= LEN(@word))
	BEGIN
		IF (CHARINDEX(SUBSTRING(@word, @I, 1), @setOfLetters) = 0)
            RETURN 0;
        SET @I += 1;
	END
    RETURN 1;
END
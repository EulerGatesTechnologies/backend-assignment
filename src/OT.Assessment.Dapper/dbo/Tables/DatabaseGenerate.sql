CREATE STATISTICS [DatabaseGenerate]
	ON [dbo].[SomeTableOrView]
		(SomeColumn)
	WITH
	SAMPLE 50 PERCENT

CREATE TABLE [dbo].[Assignments]
(
	[ID]  INT IDENTITY (1,1) NOT NULL,
	[PriorityOrder] NVARCHAR (MAX) NOT NULL,
	[DueDate] DATE NOT NULL,
	[Department] NVARCHAR (MAX) NOT NULL,
	[DueTime] DATETIME NOT NULL,
	[CourseID] NVARCHAR (MAX) NOT NULL,
	[HomeworkTitle] NVARCHAR (MAX) NOT NULL,
	[Notes] NVARCHAR (MAX) NULL,
	CONSTRAINT [Pk_dbo.Assignments] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Assignments] (PriorityOrder, DueDate, Department, DueTime, CourseID, HomeworkTitle, Notes) VALUES
	( 'High', '2019-11-2', 'CS', '2:00:00', '460', 'HW1', 'BLAHBLAH'),
	( 'Low', '2019-11-22', 'CS', '8:00:00', '460', 'HW2', 'BLAHBLAH' ),
	( 'Medium', '2019-11-21', 'CS', '12:00:00', '460', 'HW3', 'BLAHBLAH' ),
	( 'Low', '2019-11-12', 'CS', '1:00:00', '460', 'HW4', 'BLAHBLAH' ),
	( 'Low', '2019-1-12', 'CS', '1:00:00', '460', 'HW5', 'BLAHBLAH' )

	GO


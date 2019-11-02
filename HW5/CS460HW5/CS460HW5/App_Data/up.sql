CREATE TABLE [dbo].[Assignment]
(
	[ID]  INT IDENTITY (1,1) NOT NULL,
	[PriorityOrder] INT NOT NULL,
	[DueDate] DATETIME NOT NULL,
	[Department] NVARCHAR NOT NULL,
	[DueTime] DATETIME NOT NULL,
	[CourseID] NVARCHAR NOT NULL,
	[HomeworkTitle] NVARCHAR NOT NULL,
	[Notes] NVARCHAR NULL,
	CONSTRAINT [Pk_dbo.Assignment] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Assignment] (PriorityOrder, DueDate, Department, DueTime, CourseID, HomeworkTitle) VALUES
	( "1", "2019-11-2", "CS", "12:00:00", "460", "HW1" ),
	( "1", "2019-11-2", "CS", "12:00:00", "460", "HW2" ),
	( "1", "2019-11-2", "CS", "12:00:00", "460", "HW3" ),
	( "1", "2019-11-2", "CS", "12:00:00", "460", "HW4" )

	GO


using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using helloworld.Models;
using helloworld.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.ComponentModel;

namespace DataBaseTest
{
    public class UnitTest1
    {
        private List<Notes> GetMockDatabase(){
            return new List<Notes>{
                new Notes{
                    id = 1,
                    title = "Things to do",
                    text= "what to do",
                    checklist = new List<Checklist>{
                        new Checklist{
                            checkid = 1,
                            write = "nothings gonna happen",
                            ischecked=true,
                            id = 1
                        }
                    },
                    label = new Label{
                            labelid = 1,
                            text = "ASP.NETCore",
                            id=1
                        },
                    pinned=true
                
                },
                new Notes{
                    id = 2,
                    title = "Trial",
                    text="fjhdsfsj",
                    checklist = new List<Checklist>{
                        new Checklist{
                            checkid = 2,
                            write= "If you eat half, other half is left",
                            id=2
                        }
                    },
                    label = new Label{
                            labelid = 2,
                            text = "Trial",
                            id=2
                        },
                    pinned=true
                    }
                
            };
        }

        [Fact]
        public void GetAll_Positive()
        {
            var mockdata = new Mock<IRepo>();
            List<Notes> notes = GetMockDatabase();
            mockdata.Setup(d => d.GetAllNotes()).Returns(notes);
            NotesController notescontroller = new NotesController(mockdata.Object);
            var result = notescontroller.GetAllNotes();
            Assert.NotNull(result);
            Assert.Equal(2 , notes.Count);

        }

        [Fact]
        public void GetById_Positive()
        {
            var mockdata = new Mock<IRepo>();
            List<Notes> notes= GetMockDatabase();
            mockdata.Setup(d=> d.GetNotesById(2)).Returns(notes[1]);
            NotesController notescontroller = new NotesController(mockdata.Object);
            var result= notescontroller.GetById(2);
            var val = result as OkObjectResult;
            // Assert.NotNull(val);

            // var x = object.Value as Models.Resource;
            // Assert.NotNull(x);

            // var actual = x.Description;
            // Assert.Equal(expected, actual);
            Assert.NotNull(result);
            // Notes expected=result.Description;
            Assert.Same(val.Value as Notes,notes[1]);

        }

         [Fact]
        public void GetById_Negative()
        {
            var mockdata = new Mock<IRepo>();
            List<Notes> notes= GetMockDatabase();
            mockdata.Setup(d=> d.GetNotesById(3)).Returns(notes.FirstOrDefault(n=>n.id==3));
            NotesController notescontroller = new NotesController(mockdata.Object);
            var result= notescontroller.GetById(3);
            var val = result as OkObjectResult;
            // Assert.NotNull(val);

            // var x = object.Value as Models.Resource;
            // Assert.NotNull(x);

            // var actual = x.Description;
            // Assert.Equal(expected, actual);
            Assert.Null(val);
            // Notes expected=result.Description;
            Assert.Same(null, val);

        }

        [Fact]
        public void GetByLabel_Positive()
        {
            var mockdata= new Mock<IRepo>();
            List<Notes> notes= GetMockDatabase();
            mockdata.Setup(d=>d.GetNotesByLabelortitle("Trial","title"))
                        .Returns(notes.Where( n => n.title == "Trial").ToList());
            NotesController notesController= new NotesController(mockdata.Object);
            var result=notesController.GetByLabels("Trial","title");
            var val= result as OkObjectResult;
            Assert.NotNull(val);
            Assert.Equal(notes.Where( n => n.title == "Trial").ToList(),val.Value as List<Notes>);
            // Console.WriteLine(notes.Where(n => n.title == "trial").ToList());
            // Console.WriteLine(val.Value as List<Notes>);
            }

        [Fact]
        public void GetByLabel_Negative()
        {
            var mockdata= new Mock<IRepo>();
            List<Notes> notes= GetMockDatabase();
            mockdata.Setup(d=>d.GetNotesByLabelortitle(null,"title"))
                        .Returns(notes.Where( n => n.title == null).ToList());
            NotesController notesController= new NotesController(mockdata.Object);
            var result=notesController.GetByLabels(null,"title");
            var val= result as OkObjectResult;
            Assert.Null(val);
            // Console.WriteLine(val.Value as string);
            Assert.Same(null, val);
            // Console.WriteLine(notes.Where(n => n.title == "trial").ToList());
            // Console.WriteLine(val.Value as List<Notes>);
            }

        [Fact]
        public void GetByPinned_Positive()
        {
            var mockdata= new Mock<IRepo>();
            List<Notes> notes= GetMockDatabase();
            mockdata.Setup(d=> d.GetNotesByPinned(true)).Returns(notes.Where(n=> n.pinned==true).ToList());
            NotesController notescontroller=new  NotesController(mockdata.Object);
            var result= notescontroller.GetByPinned(true);
            var val=result as OkObjectResult;
            Assert.NotNull(val);
            Assert.Equal(notes.Where(n=> n.pinned== true).ToList(),val.Value as List<Notes>);
        }

        [Fact]
        public void GetByPinned_Negative()
        {
            var mockdata= new Mock<IRepo>();
            List<Notes> notes= GetMockDatabase();
            mockdata.Setup(d=> d.GetNotesByPinned(false)).Returns(notes.Where(n=> n.pinned==false).ToList());
             NotesController notescontroller=new  NotesController(mockdata.Object);
            var result= notescontroller.GetByPinned(false);
            var val=result as OkObjectResult;
            Assert.NotNull(val);
            Assert.Equal(notes.Where(n=> n.pinned== false).ToList(),val.Value as List<Notes>);

        }

}

    }
    


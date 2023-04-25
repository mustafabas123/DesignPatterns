using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher mustafa = new Teacher(mediator);
            mustafa.Name = "Mustafa";
            mediator.teacher = mustafa;

            Student student1 = new Student(mediator);
            student1.Name = "Ali";
            Student student2 = new Student(mediator);
            student2.Name = "Ayşe";

            mediator.Students=new List<Student> { student1, student2 };

            mustafa.SendNewImageUrl("test.jpg");
            Console.ReadLine();

        }
    }
    abstract class CourseMember
    {
        protected Mediator _mediator;
        public CourseMember(Mediator mediator)
        {
            _mediator = mediator;
        }
    }

    class Teacher: CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0} ,{1} ",student.Name,question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            _mediator.UpdateImage(url); //bütün öğrencilere görseli göndermiş olduk
        }
        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher  answered question {0},{1}",student.Name,answer);
        }
    }
    class Student: CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }
        public void RecieveImage(string imageUrl)
        {
            Console.WriteLine("{1} received image : {0}",imageUrl,Name);
        }
        public void ReceiveAnswer(string url)
        {
            Console.WriteLine("Student received image : {0} ",url);
        }
    }
    class Mediator
    {
        public Teacher teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string imageUrl)
        {
            foreach(var student in Students)
            {
                student.RecieveImage(imageUrl);
            }
        }
        public void SendQuestion(string question,Student student)
        {
            teacher.RecieveQuestion(question, student);
        }
        public void SendAnswer(string answer,Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}

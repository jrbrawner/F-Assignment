open System
open System.Net
open System.IO

let reader = new StreamReader(@"C:\Users\jrbbr\OneDrive\Desktop\CS379\Assignment5\Assignment5\Assignment5\Students.txt")
let csv = reader.ReadToEnd()

let malachi = "Constant,Malachi,C,8127541234,mconstant@mail.usi.edu,4.0"

let studentSeq = 
    csv.Split([|'\n'|])

let index = studentSeq |> Seq.findIndex(fun x -> x > malachi)
let newStudentSeq = studentSeq |> Seq.insertAt index malachi

let gradesOverThree = 
    newStudentSeq |> Seq.map(fun line -> line.Split([|','|]))
    |> Seq.map(fun values -> double values.[5])
    |> Seq.filter(fun grade -> grade >= 3.0)

let andersons = 
    newStudentSeq |> Seq.filter(fun line -> line.Contains("Anderson"))
    |> Seq.map(fun anderson -> anderson.Split([|','|]))
    |> Seq.map(fun value -> value.[0] + "," + value.[1] + "," + value.[2] + "," + value.[5])
    |> Seq.indexed

let noEmail =
    newStudentSeq |> Seq.map(fun line -> line.Split([|','|]))
    |> Seq.map(fun values -> string values.[4])
    |> Seq.filter(fun email -> email.Equals("NONE"))

let grades = 
    newStudentSeq |> Seq.map(fun line -> line.Split([|','|]))
    |> Seq.map(fun values -> double values.[5])

[<EntryPoint>]
let main argv =
    printfn "%O %i" ("Students with a GPA of 3.0 or higher:") (Seq.length(gradesOverThree))
    printfn"%O %i %O" ("There are") (Seq.length(andersons)) ("students with the last name of Anderson.") 
    for (i, s) in andersons do printfn "%O %O" i s
    printfn "%O %i" ("Students who do not have an email account:") (Seq.length(noEmail))
    printfn "%O %O" ("The average GPA of all students is:") (grades |> Seq.average)
    printfn "%O %i %O" ("There are") (Seq.length(newStudentSeq)) ("students total.")


    0 // return an integer exit code







    
        

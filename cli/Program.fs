module Program
open FSharp.Text.Lexing
open JsonParsing

let simpleJson = @"{
              ""title"": ""Cities"",
              ""cities"": [
                { ""name"": ""Chicago"",  ""zips"": [60601,60600] },
                { ""name"": ""New York"", ""zips"": [10001] } 
              ]
            }"

let parse json = 
    let lexbuf = LexBuffer<char>.FromString json in
    let res = Parser.start Lexer.read lexbuf in
    res

[<EntryPoint>]
let main argv =
    match parse simpleJson with
    | Some x -> jsonPrinter x |> printf "%s"; 0
    | _ -> 0

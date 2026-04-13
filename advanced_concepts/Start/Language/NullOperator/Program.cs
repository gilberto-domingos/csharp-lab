void OldSchoolLogString(string? theString) {
    if (theString == null) {
        Console.WriteLine("Nenhuma string forncecida");
    }
    else {
        Console.WriteLine(theString);
    }
}

OldSchoolLogString("String de teste");
OldSchoolLogString(null);

string? Str = null;
//string? Str = "Alguma String";

Str ??= "Se a string for nula vai mostrar essa string ou mensagem";
Console.WriteLine(Str);

namespace go.github.com.spf13;

partial class pflag_package {

internal delegate error boolfuncValue(@string _);

internal static error Set(this boolfuncValue f, @string s) {
    return f(s);
}

// Hoisted @string literals (single allocation; Go keeps these in RODATA)
internal static readonly @string boolfuncˢ = "boolfunc"u8;

internal static @string Type(this boolfuncValue f) {
    return boolfuncˢ;
}

internal static @string String(this boolfuncValue f) {
    return ""u8;
}

internal static bool IsBoolFlag(this boolfuncValue f) {
    return true;
}

public static void BoolFunc(this ж<FlagSet> Ꮡf, @string name, @string usage, Func<@string, error> fn) {
    Ꮡf.BoolFuncP(name, ""u8, usage, fn);
}

public static void BoolFuncP(this ж<FlagSet> Ꮡf, @string name, @string shorthand, @string usage, Func<@string, error> fn) {
    Value val = new boolfuncValueᴠValue(NilSafeDelegateConversion<boolfuncValue, Func<@string, error>>(fn));
    var flag = Ꮡf.VarPF(val, name, shorthand, usage);
    flag.Value.NoOptDefVal = trueˢ;
}

public static void BoolFunc(@string name, @string usage, Func<@string, error> fn) {
    CommandLine.BoolFuncP(name, ""u8, usage, fn);
}

public static void BoolFuncP(@string name, @string shorthand, @string usage, Func<@string, error> fn) {
    CommandLine.BoolFuncP(name, shorthand, usage, fn);
}

} // end pflag_package

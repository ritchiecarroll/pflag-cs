namespace go.github.com.spf13;

using bytes = bytes_package;
using fmt = fmt_package;
using strconv = strconv_package;
using strings = strings_package;

partial class pflag_package {

partial struct stringToInt64Value {
    internal ж<map<@string, int64>> value;
    internal bool changed;
}

internal static ж<stringToInt64Value> newStringToInt64Value(map<@string, int64> val, ж<map<@string, int64>> Ꮡp) {
    var ssv = @new<stringToInt64Value>();
    ssv.Value.value = Ꮡp;
    (~ssv).value.ValueSlot = val;
    return ssv;
}

internal static error Set(this ref stringToInt64Value s, @string val) {
    var ss = strings.Split(val, ","u8);
    var @out = new map<@string, int64>(len(ss));
    foreach (var (_, pair) in ss) {
        var kv = strings.SplitN(pair, "="u8, 2);
        if (len(kv) != 2) {
            return fmt.Errorf("%s must be formatted as key=value"u8, pair);
        }
        error err = default!;
        (@out[kv[0]], err) = strconv.ParseInt(kv[1], 10, 64);
        if (err != default!) {
            return err;
        }
    }
    if (!s.changed){
        s.value.ValueSlot = @out;
    } else {
        foreach (var (k, v) in @out) {
            (s.value.ValueSlot)[k] = v;
        }
    }
    s.changed = true;
    return default!;
}

// Hoisted @string literals (single allocation; Go keeps these in RODATA)
internal static readonly @string stringToInt64ˢ = "stringToInt64"u8;

internal static @string Type(this ref stringToInt64Value s) {
    return stringToInt64ˢ;
}

internal static @string String(this ref stringToInt64Value s) {
    ref var buf = ref heap(new bytes.Buffer(), out var Ꮡbuf);
    nint i = 0;
    foreach (var (k, v) in s.value.ValueSlot) {
        if (i > 0) {
            buf.WriteRune((rune)',');
        }
        buf.WriteString(k);
        buf.WriteRune((rune)'=');
        buf.WriteString(strconv.FormatInt(v, 10));
        i++;
    }
    return "["u8 + Ꮡbuf.String() + "]"u8;
}

internal static (any, error) stringToInt64Conv(@string val) {
    val = strings.Trim(val, "[]"u8);
    if (len(val) == 0) {
        return (new map<@string, int64>{}, default!);
    }
    var ss = strings.Split(val, ","u8);
    var @out = new map<@string, int64>(len(ss));
    foreach (var (_, pair) in ss) {
        var kv = strings.SplitN(pair, "="u8, 2);
        if (len(kv) != 2) {
            return (default!, fmt.Errorf("%s must be formatted as key=value"u8, pair));
        }
        error err = default!;
        (@out[kv[0]], err) = strconv.ParseInt(kv[1], 10, 64);
        if (err != default!) {
            return (default!, err);
        }
    }
    return (@out, default!);
}

public static (map<@string, int64>, error) GetStringToInt64(this ж<FlagSet> Ꮡf, @string name) {
    var (val, err) = Ꮡf.getFlagType(name, stringToInt64ˢ, stringToInt64Conv);
    if (err != default!) {
        return (new map<@string, int64>{}, err);
    }
    return (val._<map<@string, int64>>(), default!);
}

public static void StringToInt64Var(this ж<FlagSet> Ꮡf, ж<map<@string, int64>> Ꮡp, @string name, map<@string, int64> value, @string usage) {
    Ꮡf.VarP(new stringToInt64ValueжValue(newStringToInt64Value(value, Ꮡp)), name, ""u8, usage);
}

public static void StringToInt64VarP(this ж<FlagSet> Ꮡf, ж<map<@string, int64>> Ꮡp, @string name, @string shorthand, map<@string, int64> value, @string usage) {
    Ꮡf.VarP(new stringToInt64ValueжValue(newStringToInt64Value(value, Ꮡp)), name, shorthand, usage);
}

public static void StringToInt64Var(ж<map<@string, int64>> Ꮡp, @string name, map<@string, int64> value, @string usage) {
    CommandLine.VarP(new stringToInt64ValueжValue(newStringToInt64Value(value, Ꮡp)), name, ""u8, usage);
}

public static void StringToInt64VarP(ж<map<@string, int64>> Ꮡp, @string name, @string shorthand, map<@string, int64> value, @string usage) {
    CommandLine.VarP(new stringToInt64ValueжValue(newStringToInt64Value(value, Ꮡp)), name, shorthand, usage);
}

public static ж<map<@string, int64>> StringToInt64(this ж<FlagSet> Ꮡf, @string name, map<@string, int64> value, @string usage) {
    ref var p = ref heap<map<@string, int64>>(out var Ꮡp);
    p = new map<@string, int64>{};
    Ꮡf.StringToInt64VarP(Ꮡp, name, ""u8, value, usage);
    return Ꮡp;
}

public static ж<map<@string, int64>> StringToInt64P(this ж<FlagSet> Ꮡf, @string name, @string shorthand, map<@string, int64> value, @string usage) {
    ref var p = ref heap<map<@string, int64>>(out var Ꮡp);
    p = new map<@string, int64>{};
    Ꮡf.StringToInt64VarP(Ꮡp, name, shorthand, value, usage);
    return Ꮡp;
}

public static ж<map<@string, int64>> StringToInt64(@string name, map<@string, int64> value, @string usage) {
    return CommandLine.StringToInt64P(name, ""u8, value, usage);
}

public static ж<map<@string, int64>> StringToInt64P(@string name, @string shorthand, map<@string, int64> value, @string usage) {
    return CommandLine.StringToInt64P(name, shorthand, value, usage);
}

} // end pflag_package

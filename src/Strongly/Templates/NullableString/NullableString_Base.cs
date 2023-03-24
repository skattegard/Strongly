﻿readonly partial struct TYPENAME : INTERFACES
{
    public string? Value { get; }

    public TYPENAME(string? value)
    {
        Validate(value);
        Value = value;
    }

    public TYPENAME()
    {
        string? value = null;
        Validate(value);
        Value = value;
    }
    
    static partial void Validate(string? value);
    
    public static readonly TYPENAME Empty = new TYPENAME(string.Empty);

    public bool Equals(TYPENAME other)
    {
        return (Value, other.Value) switch
        {
            (null, null) => true,
            (null, _) => false,
            (_, null) => false,
            (_, _) => Value.Equals(other.Value),
        };
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is TYPENAME other && Equals(other);
    }

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
    public override string? ToString() => Value;
    public static bool operator ==(TYPENAME a, TYPENAME b) => a.Equals(b);
    public static bool operator !=(TYPENAME a, TYPENAME b) => !(a == b);

    public static TYPENAME Parse(string? value) => new TYPENAME(value);
    public static bool TryParse(string? value, out TYPENAME result)
    {
        result = new TYPENAME(value?.Trim());
        return true;
    }
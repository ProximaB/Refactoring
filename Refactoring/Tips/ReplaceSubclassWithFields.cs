namespace Refactoring.Tips
{
    public class ReplaceSubclassWithFields
    {
	    public abstract class PersonBefore
	    {
			public abstract bool IsMale();
		    public abstract char GetCode();
		}

	    public class Male : PersonBefore
	    {
		    public override bool IsMale() => true;

		    public override char GetCode() => 'M';
	    }

	    public class Female : PersonBefore
	    {
		    public override bool IsMale() => false;

		    public override char GetCode() => 'F';
	    }

	    public class PersonAfter
	    {
		    private readonly bool _isMale;
		    private char Code { get; }

		    public PersonAfter(bool isMale, char code)
		    {
			    _isMale = isMale;
			    Code = code;
		    }

		    public bool IsMale()
		    {
			    return _isMale;
		    }
	    }
    }
}

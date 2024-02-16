function clicked(e)
{
    if (!confirm('Are you sure?'))
    {
        e.preventDefault();
    }
}

function showInvalidSubmission(message)
{
    alert(message);
}
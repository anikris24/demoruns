import datetime
from fastmcp import FastMCP

# 1. Initialize the FastMCP app
app = FastMCP(
    name="dateInfoTool", 
    description="A tool for retrieving the current date and time information."
)

# 2. Define the Tool Function
@app.tool
def get_date_info(timezone: str) -> str:
    """
    Retrieves the current date and time. Use this when the user needs to know 
    what the current date or time is, or a date in a specific timezone.
    
    @param timezone: The timezone to get the current time for, e.g., 'America/New_York'. 
                     If not specified by the user, assume UTC.
    @returns A string with the current date, time, and the specified timezone.
    """
    try:
        # Get the current time in the requested timezone
        tz = datetime.timezone.utc
        if timezone:
            import pytz
            tz = pytz.timezone(timezone)
        
        current_time = datetime.datetime.now(tz)
        
        return f"The current date and time in {timezone if timezone else 'UTC'} is: {current_time.strftime('%Y-%m-%d %H:%M:%S %Z')}"
    
    except Exception as e:
        return f"Error: Could not determine time for timezone '{timezone}'. Please provide a valid IANA timezone name."

# 3. Run the server using the standard I/O (stdio) transport
if __name__ == "__main__":
    app.run_stdio()
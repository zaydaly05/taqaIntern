buider.Services.AddEndpointsApiExplorer(); 
buider.Services.AddSwaggerGen(); 
if(app.Environment.IsDevelopment())
{
app.UseSwagger(); 
app.UseSwaggerUI();

}

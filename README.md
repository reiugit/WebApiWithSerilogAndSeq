# WebAPI with Serilog and Seq

Using the following Serilog sinks:
* Console
* Seq

### Prerequisite:
* Start 'Seq' as a docker container:
<pre>
docker run --name seq -d --rm -e ACCEPT_EULA=y -p 5341:80 datalust/seq
</pre>

### Enrichers:
    Enrich.WithProperty(...)
    
    Enrich.FromLogContext()

var restify = require('restify');
db = require('../server/db');

var server = restify.createServer();
server.use(restify.plugins.bodyParser());

function getPostId(req) {
    var id = parseInt(req.params.id, 10);
    // se l'id nella richiesta non è un numero
    // serve nel db e non nel file, perché il metodo query sennò da errore perché non matcha il tipo di id con il tipo dell'attributo nel db
    /* if(isNaN(id)) {
        throw fastify.httpErrors.badRequest();
    } */
    return id;
}

server.get('/drones', function(req, res, next) {
    res.send('List of drones: [TODO]');
    return next();
});

server.get('/drones/:id', function(req, res, next) {
    res.send('Current values for drone ' + req.params['id'] + ': [TODO]');
    return next();
});

server.post('/drones/:id/status', function(req, res, next) {
    res.send('Data received from drone [TODO]');

    var Id = getPostId(req);
    value = JSON.parse(req.body);

    if(Array.isArray(value)) {
        value.forEach((v) => {
            var newValue = {Id, ...v}
            db.InsertValue(newValue);
        });
    }
    else {
        var newValue = {Id, ...value}
        db.InsertValue(newValue);
    }

    return next();
});

server.listen(8011, function() {
    console.log('%s listening at %s', server.name, server.url);
});

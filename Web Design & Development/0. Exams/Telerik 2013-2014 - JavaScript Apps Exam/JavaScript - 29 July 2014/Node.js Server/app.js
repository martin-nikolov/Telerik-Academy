var express = require('express'),
  config = require('./config/config'),
  //serves as a database, all data is saved in memory
  data = require('./app/data/data');

var app = express();

require('./config/express')(app, config);
require('./config/routes')(app, data);

app.listen(config.port);

console.log('Server running on port ' + config.port);
var data = {};

function saveValue(key, value){
	if(!data[key]){
		data[key] = {
			lastValueId: 0,
			values: []
		};
	}
	value.id = ++data[key].lastValueId;
	data[key].values.push(value);
	return this;
}

function getValues(key){
	if(!data[key]){
		return [];
	}
	return data[key].values.slice(0);
}

function findValueById(key, id){
	if(!data[key]){
		return null;
	}
	var values = data[key].values;
	for(var i = 0, len = values.length; i < len; i+=1){
		if(values[i].id === id){
			return values[i];
		}
	}
	return null;
}

function updateValue(key, value){
	values = data[key].values;
	for(var i = 0, len = values.length; i < len; i+=1){
		if(values[i].id === value.id){
			values[i] = value;
		}
	}
	return this;
}

module.exports = {
	save: saveValue,
	get: getValues,
	findById: findValueById,
	update: updateValue
};

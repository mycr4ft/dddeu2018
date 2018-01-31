const fs = require('fs');

const file = fs.readFileSync('./DSL.json', 'utf-8');
const json = JSON.parse(file);

const {Events, Commands} = json;

const dslTypeToCs = (type) => {
    switch (type) {
        case "integer": return "int";
        case "string": return "string";
    }
}

const createAttribute = (key, json) => {
    const type = dslTypeToCs(json);
    return `public ${type} ${key} {get;}`;
}


const createAttributes = (json) => {
    return attributes = Object.keys(json).map((key) => {
        if (key === "aggregateId") return "";
        return createAttribute(key, json[key]);
    }).filter(x => x !== "").join("\n");
}

const createConstructor = (json, name) => {
    let result = "";
    result += `public ${name} (`;
    const createConstructorArgument = (name, type) => {
        type = dslTypeToCs(type);
        return `${type} ${name}Arg`;
    }
    const attributes = Object.keys(json).map((key) => {
        if (key === "aggregateId") return "";
        return createConstructorArgument(key, json[key]);
    }).filter(x => x !== "");
    result += attributes.join(", ");
    result += `) {`;
    const constructorBody = Object.keys(json).map((key) => {
        if (key === "aggregateId") return "";
        return `${key} = ${key}Arg;`;
    }).filter(x => x !== "").join("\n");
    const aggregateId = Object.keys(json).map((key) => {
        if (key === "aggregateId") {
            return `public string AggregateId() { return ${json[key]};}`
        }
        return "";
    }).filter(x => x !== "").join("\n");
    result += constructorBody;
    result += `}\n`;
    result += aggregateId;
    return result;
}

const createMessage = (key, json, type) => {
    let cs = "";
    cs += `/**\n`;
    cs += `This code was generated by THE SPARKLING EVENTUAL CONSISTENT UNICORNS\n`;
    cs += `Do not touch or risk the wrath of the ECUs\n`;
    cs += `This ${type} was generated from DSL.json\n`;
    cs += `*/\n`;
    if (type === "Command") {
        cs += `using Acme.Commands;\n`;
        cs += `namespace Acme.Commands {`;
        cs += `public class ${key}: Command {`;
    } else {
        cs += `using Acme.Events;\n`;
        cs += `namespace Acme.Events {`;
        cs += `public class ${key}: Event {`;
    }
    cs += createAttributes(json);
    cs += createConstructor(json, key);
    cs += `}}`
    return cs;
}

const createPath = (key, type) => {
    if (type === "Event") {
        return `./Acme/Events/${key}Event.cs`;
    } else {
        return `./Acme/Commands/${key}Command.cs`;
    }
}
const writeMessage = (content, path) => {
    fs.writeFileSync(path, content);
}


Object.keys(Commands).forEach(element => {
    const content = createMessage(element, Commands[element], "Command")

    const path = createPath(element, "Command");

    writeMessage(content, path);
});

Object.keys(Events).forEach(element => {
    const content = createMessage(element, Events[element], "Event")

    const path = createPath(element, "Event");

    writeMessage(content, path);
});
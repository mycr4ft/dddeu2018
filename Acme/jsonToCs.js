const fs = require('fs');

const file = fs.readFileSync('./DSL.json', 'utf-8');
const json = JSON.parse(file);
console.log(json);

const {Events, Commands} = json;

const createAttribute = (key, json) => {
    const type = json;
    return `public ${type} ${key} {get; private set;}`;
}

const createAttributes = (json) => {
    const attributes = Object.keys(json).map((key) => {
        return createAttribute(key, json[key]);
    });
    return attributes.join("\n");
}

const createMessage = (key, json, type) => {
    let cs = "";
    if (type === "Command") {
        cs += `namespace Acme.Command.${key} {`;
        cs += `public class ${key}Command {`;
    } else {
        cs += `namespace Acme.Event.${key} {`;
        cs += `public class ${key}Event {`;
    }
    console.log(json);
    cs += createAttributes(json);
    cs += `}}`
    return cs;
}

const createPath = (key, type) => {
    if (type === "Event") {
        return `./events/${key}Event.cs`;
    } else {
        return `./commands/${key}Command.cs`;
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

import http from "k6/http";
import { check } from "k6";

// import add from "./add.js";
// import subs from "./subs.js";
// import hello from "./hello.js";
// import faulty from "./faulty.js";

export let options = {
    vus: 100,
    duration: "5s"
  };

export default function() {
    let responses = http.batch([
        ["GET", "http://localhost:5143/api/Sum?number1=12&number2=13"],
        ["GET", "http://localhost:5143/api/Sub?number1=12&number2=13"],
        ["GET", "http://localhost:5143/api/Hello/World"],
        ["GET", "http://localhost:5143/api/Faulty?name=Hello"]
      ]);

      check(responses[0], {
        "status is 200": (r) => r.status === 200
      });
    
      check(responses[1], {
        "status is 200": (r) => r.status === 200
      });
    
      check(responses[2], {
        "status is 200": (r) => r.status === 200
      });

      check(responses[3], {
        "status is 200": (r) => r.status === 200
      });
    
    // http.get('http://localhost:5143/Hello');
    // sleep(1);
}


import http from "k6/http";
import { check } from "k6";

export default function() {
    let res = http.get("http://localhost:5143/api/Sum?number1=12&number2=13");
    check(res, {
      "status is 200": (r) => r.status === 200
    });
  }



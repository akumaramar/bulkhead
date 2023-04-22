import http from "k6/http";
import { check } from "k6";

export default function() {
    let res = http.get("http://localhost:5143/api/Faulty?name=Hello");
    check(res, {
      "status is 200": (r) => r.status === 200
    });
  }




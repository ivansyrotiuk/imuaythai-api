import React from "react"
import Row from "./Table/Row"

export default class Table extends React.Component {
    render() {
        
//sample data
 const Clients = [
      {
          Firstname : "Jan",
          Surname : "Kowalski",
          Email: "jan.kowalski@kej.pl"
      },
      {
          Firstname : "Jakub",
          Surname : "Mudak",
          Email: "kuba.nowak@gamil.pl"
      },
      {
          Firstname : "Marzena",
          Surname : "Mostowiak",
          Email: "maerzea@ad.pl"
      },
      {
          Firstname : "Jan",
          Surname : "Kowalski",
          Email: "jan.kowalski@kej.pl"
      },
      {
          Firstname : "Jan",
          Surname : "Kowalski",
          Email: "jan.kowalski@kej.pl"
      },
      {
          Firstname : "Jan",
          Surname : "Kowalski",
          Email: "jan.kowalski@kej.pl"
      }
    ].map((client, i) => <Row key={i} client={client} count={i+1}/> );

        return (
            <div>
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Firstname</th>
                            <th>Surname</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                       {Clients}
                    </tbody>
                </table>
            </div>
        );
    }
}

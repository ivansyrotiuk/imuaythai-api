import React, { Component } from "react";
class AccordionItem extends Component {
  constructor() {
    super();
    this.state = {
      active: false
    };
  }

  onToggle() {
    this.setState(prevState => ({ active: !prevState.active }));
  }
  render() {
    return (
      <div className="card">
        <div className="card-header" role="tab" id="headingOne">
          <h5 className="mb-0">
            <div
              data-toggle="collapse"
              aria-expanded="false"
              aria-controls="collapseOne"
              className="collapsed">
              Collapsible Group Item #1
            </div>
          </h5>
        </div>

        <div
          id="collapseOne"
          className="collapse show"
          role="tabpanel"
          aria-labelledby="headingOne"
          data-parent="#accordion">
          <div className="card-body">
            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus
            terry richardson ad squid. 3 wolf moon officia aute, non cupidatat
            skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod.
            Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid
            single-origin coffee nulla assumenda shoreditch et. Nihil anim
            keffiyeh helvetica, craft beer labore wes anderson cred nesciunt
            sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings
            occaecat craft beer farm-to-table, raw denim aesthetic synth
            nesciunt you probably haven't heard of them accusamus labore
            sustainable VHS.
          </div>
        </div>
      </div>
    );
  }
}

export default AccordionItem;

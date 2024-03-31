using Bamanna.DouDian.Infrasturcture.Modules.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Modules.Common.Dto
{
    /// <summary>
    /// 适用于JsTree的Dto类
    /// </summary>
    public class JsTreeDto : UnifyEntityDtoBase<int>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public string parent { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string text { get; set; }
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public string icon { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string code { get; set; }
        /// <summary>
        /// Gets or sets the displayName.
        /// </summary>
        /// <value>The displayName.</value>
        public string displayName { get; set; }
        /// <summary>
        /// Gets or sets the memberCount.
        /// </summary>
        /// <value>The memberCount.</value>
        public int memberCount { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public JsTreeState state { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public IList<JsTreeDto> children { get; set; }
        /// <summary>
        /// Gets or sets the li_attr.
        /// </summary>
        /// <value>The li_attr.</value>
        public Dictionary<string, string> li_attr { get; set; }
        /// <summary>
        /// Gets or sets the a_attr.
        /// </summary>
        /// <value>The a_attr.</value>
        public Dictionary<string, string> a_attr { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsTreeDto"/> class.
        /// </summary>
        public JsTreeDto() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsTreeDto"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="text">The text.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="opened">if set to <c>true</c> [opened].</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        /// <param name="li_attr">The li_attr.</param>
        /// <param name="a_attr">The a_attr.</param>
        public JsTreeDto(int id, string parent, string text, string icon,
            bool opened, bool disabled, bool selected,
            Dictionary<string, string> li_attr,
            Dictionary<string, string> a_attr)
        {
            this.displayName = "";
            this.id = id;
            this.parent = parent;
            this.text = text;
            this.icon = icon;
            this.state = new JsTreeState(opened,disabled,selected);
            this.li_attr = li_attr;
            this.a_attr = a_attr;
        }
    }

    /// <summary>
    /// 树节点状态
    /// </summary>
    public class JsTreeState
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="JsTreeState"/> is opened.
        /// </summary>
        /// <value><c>true</c> if opened; otherwise, <c>false</c>.</value>
        public bool opened { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="JsTreeState"/> is disabled.
        /// </summary>
        /// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
        public bool disabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="JsTreeState"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool selected { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsTreeState"/> class.
        /// </summary>
        public JsTreeState() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsTreeState"/> class.
        /// </summary>
        /// <param name="opened">if set to <c>true</c> [opened].</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <param name="selected">if set to <c>true</c> [selected].</param>
        public JsTreeState(bool opened, bool disabled, bool selected)
        {
            this.opened = opened;
            this.disabled = disabled;
            this.selected = selected;
        }
    }

}

<xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:Locale="en-US">
      <xs:complexType>
        <xs:choice minOccurs="0" maxOccurs="unbounded">
          <xs:element name="NhomSanPham">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="NhomSanPhamID" type="xs:int" minOccurs="0" />
                <xs:element name="TenNhomSanPham" type="xs:string" minOccurs="0" />
                <xs:element name="NhomChaID" type="xs:int" minOccurs="0" />
                <xs:element name="TargetUrl" type="xs:string" minOccurs="0" />
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name="NhomCon">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="NhomSanPhamID" type="xs:int" minOccurs="0" />
                <xs:element name="TenNhomSanPham" type="xs:string" minOccurs="0" />
                <xs:element name="NhomChaID" type="xs:int" minOccurs="0" />
                <xs:element name="TargetUrl" type="xs:string" minOccurs="0" />
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name="NhomLa">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="NhomSanPhamID" type="xs:int" minOccurs="0" />
                <xs:element name="TenNhomSanPham" type="xs:string" minOccurs="0" />
                <xs:element name="NhomChaID" type="xs:int" minOccurs="0" />
                <xs:element name="TargetUrl" type="xs:string" minOccurs="0" />
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:choice>
      </xs:complexType>
    </xs:element>
    <xs:annotation>
      <xs:appinfo>
        <msdata:Relationship name="menu" msdata:parent="NhomSanPham" msdata:child="NhomCon" msdata:parentkey="NhomSanPhamID" msdata:childkey="NhomChaID" />
        <msdata:Relationship name="menucon" msdata:parent="NhomCon" msdata:child="NhomLa" msdata:parentkey="NhomSanPhamID" msdata:childkey="NhomChaID" />
      </xs:appinfo>
    </xs:annotation>
  </xs:schema>